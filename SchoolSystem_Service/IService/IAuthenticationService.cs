using SchoolSystem_Data.Helper;

namespace SchoolSystem_Service.IService
{
	public interface IAuthenticationService
	{
		public Task<JwtAuthResult> GetJWTToken(SchoolSystem_Data.Entities.Identity.User user);
		public Task<JwtAuthResult> GetRefreshToken(string accessToken, string refreshToken);
		public Task<string> ValidateToken(string accessToken);
	}
}
