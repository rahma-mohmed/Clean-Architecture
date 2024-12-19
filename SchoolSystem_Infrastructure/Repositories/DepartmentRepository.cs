using Microsoft.EntityFrameworkCore;
using SchoolSystem_Data.Entities;
using SchoolSystem_Infrastructure.Context;
using SchoolSystem_Infrastructure.InfrastructureBase;
using SchoolSystem_Infrastructure.IRepositories;

namespace SchoolSystem_Infrastructure.Repositories
{
	public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
	{
		#region Fields
		private DbSet<Department> departments;
		#endregion

		#region Constructor
		public DepartmentRepository(ApplicationDBContext dbContext) : base(dbContext)
		{
			departments = dbContext.Set<Department>();
		}
		#endregion

		#region Handle Function
		#endregion
	}
}
