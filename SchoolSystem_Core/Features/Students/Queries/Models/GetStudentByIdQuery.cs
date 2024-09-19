using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using SchoolSystem_Core.Basis;
using SchoolSystem_Core.Features.Students.Queries.Response;

namespace SchoolSystem_Core.Features.Students.Queries.Models
{
    public class GetStudentByIdQuery:IRequest<Response<GetStudentResponse>>
    {
        public int Id { get; set; }

        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
