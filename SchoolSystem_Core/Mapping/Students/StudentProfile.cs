using AutoMapper;

namespace SchoolSystem_Core.Mapping.Students
{
	public partial class StudentProfile : Profile
	{
		public StudentProfile()
		{
			GetStudentListMapping();
			GetStudentByIdMapping();
			AddStudentCommandMapping();
			EditStudentCommandMapping();
		}
	}
}
