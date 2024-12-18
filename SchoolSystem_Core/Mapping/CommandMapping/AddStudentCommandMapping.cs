using SchoolSystem_Core.Features.Students.Commands.Models;
using SchoolSystem_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem_Core.Mapping.Students
{
	public partial class StudentProfile
	{
		public void AddStudentCommandMapping()
		{
			CreateMap<AddStudentCommand, Student>().ForMember(dest => dest.DID , options => options.MapFrom(src => src.DepartmentId));
		}
	}
}
