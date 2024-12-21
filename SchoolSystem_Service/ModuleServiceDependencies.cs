using Microsoft.Extensions.DependencyInjection;
using SchoolSystem_Service.Implementations;
using SchoolSystem_Service.IService;

namespace SchoolSystem_Service
{
	public static class ModuleServiceDependencies
	{
		public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
		{
			services.AddTransient<IStudentService, StudentService>();
			services.AddTransient<IDepartmentService, DepartmentService>();
			services.AddTransient<IInstructorService, InstructorService>();
			services.AddTransient<ISubjectService, SubjectService>();
			services.AddTransient<IAuthenticationService, AuthenticationService>();
			return services;
		}
	}
}
