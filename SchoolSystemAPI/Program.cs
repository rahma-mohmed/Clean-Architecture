using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchoolSystem_Core;
using SchoolSystem_Core.Middleware;
using SchoolSystem_Infrastructure;
using SchoolSystem_Infrastructure.Context;
using SchoolSystem_Service;
using System.Globalization;

namespace SchoolSystemAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddDbContext<ApplicationDBContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("dbcontext"));
			});

			builder.Services.AddTransient<ApplicationDBContext>();

			#region Dependency Injection
			builder.Services.AddInfrastructureDependencies()
							.AddApplicationServiceseRegistration(builder.Configuration)
							.AddServiceDependencies()
							.AddCoreDependencies();
			#endregion

			#region Localization

			builder.Services.AddControllersWithViews();
			builder.Services.AddLocalization(opt =>
			{
				opt.ResourcesPath = "";
			});

			builder.Services.Configure<RequestLocalizationOptions>(options =>
			{
				List<CultureInfo> supportedCultures = new List<CultureInfo>
				{
					new CultureInfo("en-US"),
					new CultureInfo("de-DE"),
					new CultureInfo("fr-FR"),
					new CultureInfo("ar-EG")
				};

				options.DefaultRequestCulture = new RequestCulture("en-US");
				options.SupportedCultures = supportedCultures;
				options.SupportedUICultures = supportedCultures;
			});
			#endregion

			#region AllowCORS
			var CORS = "_cors";
			builder.Services.AddCors(options => options.AddPolicy(name: CORS,
				policy =>
				{
					policy.AllowAnyHeader();
					policy.AllowAnyMethod();
					policy.AllowAnyOrigin();
				}));
			#endregion

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			#region Localization MiddleWare
			var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
			app.UseRequestLocalization(options.Value);
			#endregion

			app.UseMiddleware<ErrorHandlerMiddleware>();

			app.UseHttpsRedirection();

			app.UseCors(CORS);

			app.UseAuthentication();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
