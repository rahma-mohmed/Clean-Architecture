
using Microsoft.EntityFrameworkCore;
using SchoolSystem_Infrastructure.Context;
using SchoolSystem_Infrastructure.Repositories;
using SchoolSystem_Infrastructure;
using SchoolSystem_Service;
using SchoolSystem_Core;

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

            builder.Services.AddDbContext<ApplicationDBContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("dbcontext"));
            });

            builder.Services.AddTransient<ApplicationDBContext>();

            #region Dependency Injection
            builder.Services.AddInfrastructureDependencies()
                            .AddServiceDependencies()
                            .AddCoreDependencies();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
