using Microsoft.Extensions.DependencyInjection;
using SchoolSystem_Infrastructure.InfrastructureBase;
using SchoolSystem_Infrastructure.Repositories;
using SchoolSystem_Infrastructure.IRepositories;

namespace SchoolSystem_Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services) {
            services.AddTransient<IStudentRepository, StudentsRepository>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>),typeof(GenericRepositoryAsync<>));
            return services;
        }
    }
}
