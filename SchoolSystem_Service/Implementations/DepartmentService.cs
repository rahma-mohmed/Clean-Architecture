using Microsoft.EntityFrameworkCore;
using SchoolSystem_Data.Entities;
using SchoolSystem_Data.Helper;
using SchoolSystem_Infrastructure.IRepositories;
using SchoolSystem_Service.IService;

namespace SchoolSystem_Service.Implementations
{
	public class DepartmentService : IDepartmentService
	{
		#region Fields
		private readonly IDepartmentRepository _repository;
		private readonly IInstructorRepository _instructorRepository;
		#endregion

		#region Constructors
		public DepartmentService(IDepartmentRepository repository, IInstructorRepository instructorRepository)
		{
			_repository = repository;
			_instructorRepository = instructorRepository;
		}
		#endregion

		#region Handle Function
		public async Task<Department> GetDepartmentById(int id)
		{
			var res = await _repository.GetTableNoTracking().Where(x => x.Id == id)
				.Include(x => x.Departmentsubjects)
				.ThenInclude(x => x.Subjects)
				.Include(x => x.Students)
				.Include(x => x.Instructors)
				.Include(x => x.Instructor)
				.FirstOrDefaultAsync();

			return res;
		}

		public IQueryable<Department> GetDepartmentListQuerable()
		{
			return _repository.GetTableNoTracking().Include(d => d.Instructor).AsQueryable();
		}

		public IQueryable<Department> FilterDepartmentPagination(DepartmentOrderingEnum order, string search)
		{
			var querable = _repository.GetTableNoTracking().Include(d => d.Instructor).AsQueryable();
			if (search != null)
			{
				querable = querable.Where(x => x.GetLocalized(x.DNameAr, x.DNameEn).Contains(search));
			}

			switch (order)
			{
				case DepartmentOrderingEnum.Name:
					querable = querable.OrderBy(x => x.GetLocalized(x.DNameAr, x.DNameEn));
					break;
				case DepartmentOrderingEnum.ManagerName:
					querable = querable.OrderBy(x => x.InsManager);
					break;
				default:
					querable = querable.OrderBy(x => x.Id);
					break;
			}
			return querable;
		}

		public async Task<bool> IsDepartmentIdExist(int id)
		{
			return await _repository.GetTableNoTracking().AnyAsync(x => x.Id.Equals(id));
		}

		public async Task<bool> IsDepartmentExist(string name)
		{
			return await (_repository.GetTableNoTracking().AnyAsync(x => (x.DNameAr.Equals(name) || x.DNameEn.Equals(name))));
		}

		public async Task<bool> IsInstructorIdExist(int? id)
		{
			if (id == null) return false;
			return await _instructorRepository.GetTableNoTracking().AnyAsync(x => x.InsId.Equals(id));
		}

		public async Task<string> AddAsync(Department department)
		{

			await _repository.AddAsync(department);

			return "Success";
		}

		public async Task<Department> GetByIdAsync(int id)
		{
			return await _repository.GetTableNoTracking().Where(d => d.Id == id).FirstOrDefaultAsync();
		}

		public async Task<string> DeleteAsync(Department department)
		{
			var transact = _repository.BeginTransaction();
			try
			{
				await _repository.DeleteAsync(department);
				await transact.CommitAsync();
				return "Success";
			}
			catch (Exception ex)
			{
				{
					await transact.RollbackAsync();
					return $"{ex}";
				}
			}

			#endregion
		}

		public async Task<string> EditAsync(Department department)
		{
			await _repository.UpdateAsync(department);
			return "Success";
		}
	}
}
