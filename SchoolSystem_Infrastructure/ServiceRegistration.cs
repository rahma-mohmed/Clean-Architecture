using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SchoolSystem_Data.Entities.Identity;
using SchoolSystem_Infrastructure.Context;

namespace SchoolSystem_Infrastructure
{
	public static class ServiceRegistration
	{
		public static IServiceCollection AddApplicationServiceseRegistration(this IServiceCollection services)
		{
			services.AddIdentity<User, IdentityRole<int>>(Option =>
			{
				Option.SignIn.RequireConfirmedEmail = false;
				Option.Password.RequiredLength = 6;

				Option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				Option.Lockout.MaxFailedAccessAttempts = 5;
				Option.Lockout.AllowedForNewUsers = true;

				Option.User.RequireUniqueEmail = true;

			}).AddEntityFrameworkStores<ApplicationDBContext>().AddDefaultTokenProviders();

			return services;
		}
	}
}
