using AutoMapper;
using SchoolSystem_Core.Features.Departments.Commands.Models;
using SchoolSystem_Data.Entities;

namespace SchoolSystem_Core.Mapping.Departments
{
	public partial class DepartmentProfile : Profile
	{
		public void AddDepartmentCommandMapping()
		{
			CreateMap<AddDepartmentCommand, Department>();
		}
	}
}
