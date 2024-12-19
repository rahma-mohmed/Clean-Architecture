using SchoolSystem_Core.Features.Departments.Queries.Response;
using SchoolSystem_Data.Entities;

namespace SchoolSystem_Core.Mapping.Departments
{
	public partial class DepartmentProfile
	{
		public void GetDepartmentByIdMapping()
		{
			CreateMap<Department, GetDepartmentByIdResponse>()
				.ForMember(dst => dst.Name, option => option.MapFrom(src => src.GetLocalized(src.DNameAr, src.DNameEn)))
				.ForMember(dst => dst.Id, option => option.MapFrom(src => src.Id))
				.ForMember(dst => dst.SubjectsList, option => option.MapFrom(src => src.Departmentsubjects))
				.ForMember(dst => dst.StudentsList, option => option.MapFrom(src => src.Students))
				.ForMember(dst => dst.InstructorsList, option => option.MapFrom(src => src.Instructors))
				.ForMember(dst => dst.ManagerName, option => option.MapFrom(src => src.Instructor.GetLocalized(src.Instructor.INameAr, src.Instructor.INameEn)));

			CreateMap<DepartmentSubject, SubjectResponse>()
				.ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.SubID))
				.ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Subjects.GetLocalized(src.Subjects.SubjectNameAr, src.Subjects.SubjectNameEn)));

			CreateMap<Student, StudentResponse>()
				.ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.GetLocalized(src.NameAr, src.NameEn)));

			CreateMap<Instructor, InstructorsResponse>()
				.ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.InsId))
				.ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.GetLocalized(src.INameAr, src.INameEn)));
		}
	}
}
