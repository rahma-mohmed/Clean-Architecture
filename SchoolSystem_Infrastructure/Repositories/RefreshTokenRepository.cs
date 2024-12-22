using Microsoft.EntityFrameworkCore;
using SchoolSystem_Data.Entities;
using SchoolSystem_Infrastructure.Context;
using SchoolSystem_Infrastructure.InfrastructureBase;
using SchoolSystem_Infrastructure.IRepositories;

namespace SchoolSystem_Infrastructure.Repositories
{
	public class RefreshTokenRepository : GenericRepositoryAsync<UserRefreshToken>, IRefreshTokenRepository
	{
		#region Fields
		public DbSet<UserRefreshToken> RefreshTokens;
		#endregion

		#region Constructor
		public RefreshTokenRepository(ApplicationDBContext dbContext) : base(dbContext)
		{
			RefreshTokens = dbContext.Set<UserRefreshToken>();
		}
		#endregion

		#region Handle Function
		#endregion
	}
}
