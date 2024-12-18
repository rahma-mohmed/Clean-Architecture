using SchoolSystem_Core.Features.Students.Queries.Response;
using SchoolSystem_Data.Entities;

namespace SchoolSystem_Core.Mapping.Students
{
	public partial class StudentProfile
	{
		public void GetStudentByIdMapping()
		{
			CreateMap<Student, GetStudentResponse>()
			.ForMember(std => std.DepartmentName, options => options.MapFrom(dst => dst.Departments.GetLocalized(dst.Departments.DNameAr, dst.Departments.DNameEn)))
			.ForMember(std => std.Name, options => options.MapFrom(dst => dst.GetLocalized(dst.NameAr, dst.NameEn)));
		}
	}
}
