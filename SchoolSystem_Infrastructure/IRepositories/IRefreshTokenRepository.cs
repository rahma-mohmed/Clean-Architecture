﻿using SchoolSystem_Data.Entities;
using SchoolSystem_Infrastructure.InfrastructureBase;

namespace SchoolSystem_Infrastructure.IRepositories
{
	public interface IRefreshTokenRepository : IGenericRepositoryAsync<UserRefreshToken>
	{
	}
}
