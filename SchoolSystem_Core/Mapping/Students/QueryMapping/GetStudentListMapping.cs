using SchoolSystem_Core.Features.Students.Queries.Response;
using SchoolSystem_Data.Entities;

namespace SchoolSystem_Core.Mapping.Students
{
	public partial class StudentProfile
	{
		public void GetStudentListMapping()
		{
			CreateMap<Student, GetStudentListResponse>()
					.ForMember(dst => dst.DepartmentName, options => options.MapFrom(std => std.Departments.GetLocalized(std.Departments.DNameAr, std.Departments.DNameEn)))
					.ForMember(dst => dst.Name, options => options.MapFrom(std => std.GetLocalized(std.NameAr, std.NameEn)))
					.ForMember(dst => dst.Address, options => options.MapFrom(std => std.GetLocalized(std.AddressAr, std.AddressEn)));
		}
	}
}
