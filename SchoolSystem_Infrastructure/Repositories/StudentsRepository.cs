using Microsoft.EntityFrameworkCore;
using SchoolSystem_Data.Entities;
using SchoolSystem_Infrastructure.Context;
using SchoolSystem_Infrastructure.InfrastructureBase;
using SchoolSystem_Infrastructure.IRepositories;

namespace SchoolSystem_Infrastructure.Repositories
{
	public class StudentsRepository : GenericRepositoryAsync<Student>, IStudentRepository
	{
		#region Fields
		private readonly DbSet<Student> _studentContext;
		#endregion

		#region Constructor
		public StudentsRepository(ApplicationDBContext dBContext) : base(dBContext)
		{
			_studentContext = dBContext.Set<Student>();
		}

		#endregion

		#region Handle Functions

		public async Task<List<Student>> GetStudentListAsync()
		{
			return await _studentContext.Include(s => s.Departments).ToListAsync();
		}

		#endregion
	}
}
