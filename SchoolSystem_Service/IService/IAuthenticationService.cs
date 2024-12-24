using SchoolSystem_Data.Entities.Identity;
using SchoolSystem_Data.Helper;
using System.IdentityModel.Tokens.Jwt;

namespace SchoolSystem_Service.IService
{
	public interface IAuthenticationService
	{
		public Task<JwtAuthResult> GetJWTToken(SchoolSystem_Data.Entities.Identity.User user);
		public JwtSecurityToken ReadJwtToken(string accesstoken);
		public Task<JwtAuthResult> GetRefreshToken(User user, string accessToken, string refreshToken, DateTime? expiryDate);
		public Task<string> ValidateToken(string accessToken);
		public Task<(string, DateTime?)> ValidateTokenDetails(JwtSecurityToken jwtToken, string AccessToken, string RefreshToken);
	}
}
