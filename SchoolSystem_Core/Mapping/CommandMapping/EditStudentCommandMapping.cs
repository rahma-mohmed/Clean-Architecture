using SchoolSystem_Core.Features.Students.Commands.Models;
using SchoolSystem_Data.Entities;

namespace SchoolSystem_Core.Mapping.Students
{
	public partial class StudentProfile
	{
		public void EditStudentCommandMapping()
		{
			CreateMap<EditStudentCommand, Student>().ForMember(dest => dest.DID, options => options.MapFrom(src => src.DepartmentId))
				.ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id));
		}
	}
}
