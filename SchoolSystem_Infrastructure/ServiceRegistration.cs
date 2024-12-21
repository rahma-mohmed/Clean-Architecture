using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SchoolSystem_Data.Entities.Identity;
using SchoolSystem_Data.Helper;
using SchoolSystem_Infrastructure.Context;
using System.Text;

namespace SchoolSystem_Infrastructure
{
	public static class ServiceRegistration
	{
		public static IServiceCollection AddApplicationServiceseRegistration(this IServiceCollection services, IConfiguration configuration)
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

			#region JWT Authentication
			var jwtSettings = new JwtSettings();
			configuration.GetSection("_jwtSettings").Bind(jwtSettings);
			services.AddSingleton(jwtSettings);
			#endregion

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.RequireHttpsMetadata = false;
				options.SaveToken = true;
				options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
				{
					ValidateIssuer = jwtSettings.ValidateIssuer,
					ValidIssuers = new[] { jwtSettings.Issuer },
					ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigninkey,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
					ValidateAudience = jwtSettings.ValidateAudience,
					ValidAudience = jwtSettings.Audience,
					ValidateLifetime = jwtSettings.ValidateLifeTime
				};
			});

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "School Project", Version = "v2" });
				c.EnableAnnotations();

				c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
				{
					Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey,
					Scheme = JwtBearerDefaults.AuthenticationScheme
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement
			{
			{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = JwtBearerDefaults.AuthenticationScheme
				}
			},
			Array.Empty<string>()
			}
			});
			});

			return services;
		}
	}
}
