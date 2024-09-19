using Microsoft.Extensions.DependencyInjection;
using SchoolSystem_Infrastructure.IRepositories;
using SchoolSystem_Service.Implementations;

namespace SchoolSystem_Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services) {
            services.AddTransient<IStudentService, StudentService>();
            return services;
        }
    }
}
