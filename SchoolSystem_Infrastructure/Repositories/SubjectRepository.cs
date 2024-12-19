using Microsoft.EntityFrameworkCore;
using SchoolSystem_Data.Entities;
using SchoolSystem_Infrastructure.Context;
using SchoolSystem_Infrastructure.InfrastructureBase;
using SchoolSystem_Infrastructure.IRepositories;

namespace SchoolSystem_Infrastructure.Repositories
{
	public class SubjectRepository : GenericRepositoryAsync<Subject>, ISubjectRepository
	{
		#region Fields
		private readonly DbSet<Subject> _subjects;
		#endregion

		#region Constructor
		public SubjectRepository(ApplicationDBContext dbContext) : base(dbContext)
		{
			_subjects = dbContext.Set<Subject>();
		}
		#endregion

		#region Handle Function
		#endregion
	}
}
