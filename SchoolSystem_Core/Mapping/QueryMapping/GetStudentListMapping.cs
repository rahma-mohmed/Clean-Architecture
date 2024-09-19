using SchoolSystem_Core.Features.Students.Queries.Response;
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
        public void GetStudentListMapping()
        {
            CreateMap<Student, GetStudentListResponse>()
                    .ForMember(dst => dst.DepartmentName, options => options.MapFrom(std => std.Departments.DName));    
        }
    }
}
