using Microsoft.EntityFrameworkCore;
using SchoolSystem_Data.Entities;
using SchoolSystem_Infrastructure.IRepositories;

namespace SchoolSystem_Service.Implementations
{
	public class DepartmentService : IDepartmentService
	{
		#region Fields
		private readonly IDepartmentRepository _repository;
		#endregion

		#region Constructors
		public DepartmentService(IDepartmentRepository repository)
		{
			_repository = repository;
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
		#endregion
	}
}
