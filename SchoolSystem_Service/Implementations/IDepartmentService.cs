using SchoolSystem_Data.Entities;

namespace SchoolSystem_Service.Implementations
{
	public interface IDepartmentService
	{
		public Task<Department> GetDepartmentById(int id);
		public Task<bool> IsDepartmentIdExist(int id);
	}
}
