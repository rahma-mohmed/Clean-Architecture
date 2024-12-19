using Microsoft.EntityFrameworkCore;
using SchoolSystem_Data.Entities;
using SchoolSystem_Infrastructure.Context;
using SchoolSystem_Infrastructure.InfrastructureBase;
using SchoolSystem_Infrastructure.IRepositories;

namespace SchoolSystem_Infrastructure.Repositories
{
	public class InstructorRepository : GenericRepositoryAsync<Instructor>, IInstructorRepository
	{
		#region Fields
		private readonly DbSet<Instructor> _instructors;
		#endregion

		#region Constructor
		public InstructorRepository(ApplicationDBContext dbContext) : base(dbContext)
		{
			_instructors = dbContext.Set<Instructor>();
		}
		#endregion

		#region Handle Functions
		#endregion
	}
}
