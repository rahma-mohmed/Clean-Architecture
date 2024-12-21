using SchoolSystem_Data.Entities;
using SchoolSystem_Data.Helper;

namespace SchoolSystem_Service.IService
{
	public interface IDepartmentService
	{
		public Task<Department> GetDepartmentById(int id);
		public IQueryable<Department> GetDepartmentListQuerable();
		public IQueryable<Department> FilterDepartmentPagination(DepartmentOrderingEnum order, string search);
		public Task<bool> IsDepartmentIdExist(int id);
		public Task<bool> IsDepartmentExist(string name);
		public Task<bool> IsInstructorIdExist(int? id);
		public Task<string> AddAsync(Department department);
		public Task<string> EditAsync(Department department);
		public Task<Department> GetByIdAsync(int id);
		public Task<string> DeleteAsync(Department department);
	}
}
