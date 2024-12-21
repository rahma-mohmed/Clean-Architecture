using SchoolSystem_Core.Features.Departments.Queries.Response;
using SchoolSystem_Data.Entities;

namespace SchoolSystem_Core.Mapping.Departments
{
	public partial class DepartmentProfile
	{
		public void GetDepartmentListMapping()
		{
			CreateMap<Department, GetDepartmentListResponse>()
				.ForMember(dst => dst.Id, options => options.MapFrom(src => src.Id))
				.ForMember(dst => dst.Name, options => options.MapFrom(src => src.GetLocalized(src.DNameAr, src.DNameEn)));
			//.ForMember(dst => dst.ManagerName, option => option.MapFrom(src => src.Instructor.GetLocalized(src.Instructor.INameAr, src.Instructor.INameEn)));
		}
	}
}
