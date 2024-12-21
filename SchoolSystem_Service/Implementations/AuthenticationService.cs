using Microsoft.IdentityModel.Tokens;
using SchoolSystem_Data.Entities.Identity;
using SchoolSystem_Data.Helper;
using SchoolSystem_Service.IService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolSystem_Service.Implementations
{
	public class AuthenticationService : IAuthenticationService
	{
		#region Fields
		private readonly JwtSettings _jwtSettings;
		#endregion

		#region Constructor
		public AuthenticationService(JwtSettings jwtSettings)
		{
			_jwtSettings = jwtSettings;
		}
		#endregion

		#region Handle Function
		//issure => مصدر
		//audience => مستخدم
		//claims => بيانات المستخدم
		//not before التوكين لا يتفعل قبل وقت وقت معين
		//expire
		//credentionals => secret key , algorithm

		public Task<string> GetJWTToken(User user)
		{
			var claims = new List<Claim>
			{
				new Claim(nameof(UserClaimsModel.UserName) , user.UserName),
				new Claim(nameof(UserClaimsModel.PhoneNumber) , user.PhoneNumber),
				new Claim(nameof(UserClaimsModel.Email) , user.Email)
			};

			var creditional = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature);

			var token = new JwtSecurityToken(_jwtSettings.Issuer, _jwtSettings.Audience, claims, null, DateTime.UtcNow.AddHours(2), creditional);

			var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

			return Task.FromResult(accessToken);
		}
		#endregion
	}
}
