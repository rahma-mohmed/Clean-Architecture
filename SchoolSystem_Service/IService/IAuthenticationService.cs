using SchoolSystem_Data.Helper;

namespace SchoolSystem_Service.IService
{
	public interface IAuthenticationService
	{
		public Task<JwtAuthResult> GetJWTToken(SchoolSystem_Data.Entities.Identity.User user);
	}
}
