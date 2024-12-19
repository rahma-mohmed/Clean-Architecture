using AutoMapper;

namespace SchoolSystem_Core.Mapping.Departments
{
	public partial class DepartmentProfile : Profile
	{
		public DepartmentProfile()
		{
			GetDepartmentByIdMapping();
		}
	}
}
