using SchoolSystem_Data.Entities;

namespace SchoolSystem_Service.Implementations
{
    public interface IStudentService
    {
        public Task<List<Student>> GetAllStudentsAsync();
        public Task<Student> GetStudentByIdAsync(int id);
        public Task<string> AddAsync(Student student); 
    }
}