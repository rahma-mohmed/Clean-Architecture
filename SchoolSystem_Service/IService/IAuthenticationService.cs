namespace SchoolSystem_Service.IService
{
	public interface IAuthenticationService
	{
		public Task<string> GetJWTToken(SchoolSystem_Data.Entities.Identity.User user);
	}
}
