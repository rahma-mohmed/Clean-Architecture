using Microsoft.IdentityModel.Tokens;
using SchoolSystem_Data.Entities;
using SchoolSystem_Data.Entities.Identity;
using SchoolSystem_Data.Helper;
using SchoolSystem_Infrastructure.IRepositories;
using SchoolSystem_Service.IService;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SchoolSystem_Service.Implementations
{
	public class AuthenticationService : IAuthenticationService
	{
		#region Fields
		private readonly JwtSettings _jwtSettings;
		private readonly ConcurrentDictionary<string, RefreshToken> _refreshTokenConcurrent;
		private readonly IRefreshTokenRepository _refreshTokenRepository;
		#endregion

		#region Constructor
		public AuthenticationService(IRefreshTokenRepository refreshTokenRepository, JwtSettings jwtSettings, ConcurrentDictionary<string, RefreshToken> refreshToken)
		{
			_refreshTokenConcurrent = new ConcurrentDictionary<string, RefreshToken>();
			_jwtSettings = jwtSettings;
			_refreshTokenRepository = refreshTokenRepository;
		}
		#endregion

		#region Handle Function
		//issure => مصدر
		//audience => مستخدم
		//claims => بيانات المستخدم
		//not before التوكين لا يتفعل قبل وقت وقت معين
		//expire
		//credentionals => secret key , algorithm

		public async Task<JwtAuthResult> GetJWTToken(User user)
		{
			var claims = new List<Claim>
			{
				new Claim(nameof(UserClaimsModel.UserName) , user.UserName),
				new Claim(nameof(UserClaimsModel.PhoneNumber) , user.PhoneNumber),
				new Claim(nameof(UserClaimsModel.Email) , user.Email)
			};

			var creditional = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature);

			var token = new JwtSecurityToken(_jwtSettings.Issuer, _jwtSettings.Audience, claims, null, DateTime.UtcNow.AddMinutes(5), creditional);

			var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

			#region Refresh Token
			var refreshtoken = new RefreshToken
			{
				UserName = user.UserName,
				ExpireAt = DateTime.UtcNow.AddMonths(1),
				TokenString = GenerateRefreshToken()
			};

			_refreshTokenConcurrent.AddOrUpdate(refreshtoken.TokenString, refreshtoken, (s, t) => refreshtoken);

			var userRefreshToken = new UserRefreshToken()
			{
				AddedTime = DateTime.Now,
				ExpiryDate = refreshtoken.ExpireAt,
				UserId = user.Id,
				IsUsed = false,
				IsRevoked = false,
				JwtId = token.Id,
				RefreshToken = refreshtoken.TokenString,
				JWTToken = accessToken
			};

			await _refreshTokenRepository.AddAsync(userRefreshToken);
			#endregion

			return new JwtAuthResult
			{
				AccessToken = accessToken,
				UserResfereshToken = refreshtoken
			};
		}

		private string GenerateRefreshToken()
		{
			var randomumber = new byte[32];
			var randomNumberGenerate = RandomNumberGenerator.Create();
			randomNumberGenerate.GetBytes(randomumber);

			return Convert.ToBase64String(randomumber);
		}
		#endregion
	}
}
