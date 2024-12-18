using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem_Data.Entities;
using SchoolSystem_Core.Features.Students.Queries.Response;

namespace SchoolSystem_Core.Mapping.Students
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetStudentListMapping();
            GetStudentByIdMapping();
            AddStudentCommandMapping();
		}
    }
}
