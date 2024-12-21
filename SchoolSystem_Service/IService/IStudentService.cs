using SchoolSystem_Data.Entities;
using SchoolSystem_Data.Helper;

namespace SchoolSystem_Service.IService
{
	public interface IStudentService
	{
		public Task<List<Student>> GetAllStudentsAsync();
		public Task<Student> GetStudentByIdWithIncludeAsync(int id);
		public Task<Student> GetByIdAsync(int id);
		public Task<string> AddAsync(Student student);
		public Task<bool> IsNameExist(string name);
		public Task<bool> IsNameExistExcludeSelf(string name, int id);
		public Task<string> EditAsync(Student student);
		public Task<string> DeleteAsync(Student student);
		public IQueryable<Student> GetStudentsQuerable();
		public IQueryable<Student> FilterStudentPagination(StudentOrderingEnum order, string search);
	}
}