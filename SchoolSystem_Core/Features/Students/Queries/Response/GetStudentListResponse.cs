using System;
using System.Collections.Generic;
namespace SchoolSystem_Core.Features.Students.Queries.Response
{
    public class GetStudentListResponse
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? DepartmentName { get; set; }   
    }
}
