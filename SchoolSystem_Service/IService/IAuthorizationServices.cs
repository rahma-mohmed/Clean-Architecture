namespace SchoolSystem_Service.IService
{
	public interface IAuthorizationServices
	{
		public Task<String> AddRoleAsync(String roleName);
		public Task<bool> IsRoleExist(String roleName);

	}
}
