using Microsoft.EntityFrameworkCore;
using SchoolSystem_Data.Entities;
using SchoolSystem_Infrastructure.IRepositories;

namespace SchoolSystem_Service.Implementations
{
	internal class StudentService : IStudentService
	{
		#region Filed
		private readonly IStudentRepository _studentRepository;
		#endregion

		#region Constructor
		public StudentService(IStudentRepository studentRepository)
		{
			_studentRepository = studentRepository;
		}
		#endregion

		#region Handle Functions
		public async Task<List<Student>> GetAllStudentsAsync()
		{
			return await _studentRepository.GetStudentListAsync();
		}

		public async Task<Student> GetStudentByIdAsync(int id)
		{
			var student = _studentRepository.GetTableAsTracking()
										   .Include(x => x.Departments)
										   .Where(x => x.Id == id)
										   .FirstOrDefault();
			return student;
		}

		public async Task<string> AddAsync(Student student)
		{

			await _studentRepository.AddAsync(student);

			return "Success";
		}

		public async Task<bool> IsNameExist(string name)
		{
			var studentResult = _studentRepository.GetTableNoTracking().Where(x => x.Name.Equals(name)).FirstOrDefault();

			if (studentResult == null)
			{
				return false;
			}

			return true;
		}
		#endregion
	}
}
