using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
		private readonly UserManager<User> _userManager;
		#endregion

		#region Constructor
		public AuthenticationService(UserManager<User> userManager, IRefreshTokenRepository refreshTokenRepository, JwtSettings jwtSettings, ConcurrentDictionary<string, RefreshToken> refreshToken)
		{
			_refreshTokenConcurrent = new ConcurrentDictionary<string, RefreshToken>();
			_jwtSettings = jwtSettings;
			_refreshTokenRepository = refreshTokenRepository;
			_userManager = userManager;
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
			//var claims = new List<Claim>
			//{
			//	new Claim(nameof(UserClaimsModel.UserName) , user.UserName),
			//	new Claim(nameof(UserClaimsModel.PhoneNumber) , user.PhoneNumber),
			//	new Claim(nameof(UserClaimsModel.Email) , user.Email)
			//};

			//var creditional = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature);

			//var token = new JwtSecurityToken(_jwtSettings.Issuer, _jwtSettings.Audience, claims, null, DateTime.UtcNow.AddMinutes(5), creditional);

			var (token, accesstoken) = GenerateJWTToken(user);

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
				IsUsed = true,
				IsRevoked = false,
				JwtId = token.Id,
				RefreshToken = refreshtoken.TokenString,
				JWTToken = accesstoken
			};

			await _refreshTokenRepository.AddAsync(userRefreshToken);
			#endregion

			return new JwtAuthResult
			{
				AccessToken = accesstoken,
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

		public async Task<JwtAuthResult> GetRefreshToken(string accessToken, string refreshToken)
		{
			//Read Token Get Claims
			var token = ReadJwtToken(accessToken);
			//Validation
			if (token == null || !token.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
			{
				throw new SecurityTokenException("Invalid Token, algorith is wrong");
			}
			if (token.ValidTo > DateTime.UtcNow)
			{
				throw new SecurityTokenException("Token Is Not Expired");
			}
			// GetUser
			var userId = token.Claims.FirstOrDefault(x => x.Type == nameof(UserClaimsModel.Id)).Value;
			var refreshTokenUser = await _refreshTokenRepository.GetTableNoTracking()
				.FirstOrDefaultAsync(x => (x.JWTToken == accessToken && x.RefreshToken == refreshToken && x.UserId == int.Parse(userId)));

			//check expire
			if (refreshTokenUser.ExpiryDate < DateTime.UtcNow)
			{
				refreshTokenUser.IsRevoked = true;
				refreshTokenUser.IsUsed = false;
				await _refreshTokenRepository.UpdateAsync(refreshTokenUser);
				throw new SecurityTokenException("Refresh Token Is Expired");
			}

			if (refreshTokenUser == null) throw new SecurityTokenException("Refresh Token Is Not Found");
			//Generate token
			var user = await _userManager.FindByIdAsync(userId);
			if (user == null) throw new SecurityTokenException("User Is Not Found");

			var (newtoken, newaccessToken) = GenerateJWTToken(user);

			var refreshtoken = new RefreshToken
			{
				UserName = user.UserName,
				ExpireAt = refreshTokenUser.ExpiryDate,
				TokenString = refreshToken
			};

			return new JwtAuthResult
			{
				AccessToken = newaccessToken,
				UserResfereshToken = refreshtoken
			};
		}

		private JwtSecurityToken ReadJwtToken(string AccessToken)
		{
			if (string.IsNullOrEmpty(AccessToken)) throw new ArgumentNullException(nameof(AccessToken));

			var handler = new JwtSecurityTokenHandler();

			return handler.ReadJwtToken(AccessToken);
		}

		private (JwtSecurityToken, string) GenerateJWTToken(User user)
		{
			var claims = new List<Claim>
			{
				new Claim(nameof(UserClaimsModel.UserName) , user.UserName),
				new Claim(nameof(UserClaimsModel.PhoneNumber) , user.PhoneNumber),
				new Claim(nameof(UserClaimsModel.Id) , user.Id.ToString()),
				new Claim(nameof(UserClaimsModel.Email) , user.Email)
			};

			var creditional = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature);

			var token = new JwtSecurityToken(_jwtSettings.Issuer, _jwtSettings.Audience, claims, null, DateTime.UtcNow.AddMinutes(5), creditional);

			var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

			return (token, accessToken);
		}

		public async Task<string> ValidateToken(string accessToken)
		{
			var handler = new JwtSecurityTokenHandler();

			var paramters = new TokenValidationParameters
			{
				ValidateIssuer = _jwtSettings.ValidateIssuer,
				ValidIssuers = new[] { _jwtSettings.Issuer },
				ValidateIssuerSigningKey = _jwtSettings.ValidateIssuerSigninkey,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)),
				ValidateAudience = _jwtSettings.ValidateAudience,
				ValidAudience = _jwtSettings.Audience,
				ValidateLifetime = _jwtSettings.ValidateLifeTime
			};
			var validator = handler.ValidateToken(accessToken, paramters, out SecurityToken validatedToken);
			try
			{
				if (validator == null)
				{
					throw new SecurityTokenException("Invalid Token");
				}

				return "Is Valid Token Not Expired";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}

		}
		#endregion
	}
}
