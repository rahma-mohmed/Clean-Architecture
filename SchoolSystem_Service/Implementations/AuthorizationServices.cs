using Microsoft.AspNetCore.Identity;
using SchoolSystem_Service.IService;

namespace SchoolSystem_Service.Implementations
{
	public class AuthorizationServices : IAuthorizationServices
	{
		private readonly RoleManager<IdentityRole<int>> _roleManager;

		public AuthorizationServices(RoleManager<IdentityRole<int>> roleManager)
		{
			_roleManager = roleManager;
		}

		public async Task<string> AddRoleAsync(string roleName)
		{
			var identityRole = new IdentityRole<int>();
			identityRole.Name = roleName;
			var result = await _roleManager.CreateAsync(identityRole);

			if (result.Succeeded)
			{
				return "Success";
			}
			else
			{
				return "Faild";
			}
		}

		public async Task<bool> IsRoleExist(string roleName)
		{
			var role = await _roleManager.FindByNameAsync(roleName);
			return role != null;
		}
	}
}
