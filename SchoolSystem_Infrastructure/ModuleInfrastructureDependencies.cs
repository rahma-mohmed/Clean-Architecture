using Microsoft.Extensions.DependencyInjection;
using SchoolSystem_Infrastructure.InfrastructureBase;
using SchoolSystem_Infrastructure.IRepositories;
using SchoolSystem_Infrastructure.Repositories;

namespace SchoolSystem_Infrastructure
{
	public static class ModuleInfrastructureDependencies
	{
		public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
		{
			services.AddTransient<IStudentRepository, StudentsRepository>();
			services.AddTransient<IDepartmentRepository, DepartmentRepository>();
			services.AddTransient<ISubjectRepository, SubjectRepository>();
			services.AddTransient<IInstructorRepository, InstructorRepository>();
			services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
			return services;
		}
	}
}
