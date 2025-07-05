using Microsoft.Extensions.DependencyInjection;
using SchoolSystem_Data.Helper;
using SchoolSystem_Service.Implementations;
using SchoolSystem_Service.IService;
using System.Collections.Concurrent;

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
			services.AddTransient<IAuthorizationServices, AuthorizationServices>();
			services.AddSingleton(new ConcurrentDictionary<string, RefreshToken>());
			return services;
		}
	}
}
