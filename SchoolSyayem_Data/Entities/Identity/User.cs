﻿using Microsoft.AspNetCore.Identity;

namespace SchoolSystem_Data.Entities.Identity
{
	public class User : IdentityUser<int>
	{
		public User()
		{
			UserRefreshTokens = new HashSet<UserRefreshToken>();
		}

		public string FullName { get; set; }
		public string? Address { get; set; }
		public string? Country { get; set; }

		public virtual ICollection<UserRefreshToken>? UserRefreshTokens { get; set; }
	}
}
