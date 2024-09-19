using MediatR;
using SchoolSystem_Core.Features.Students.Queries.Response;
using SchoolSystem_Core.Basis;

namespace SchoolSystem_Core.Features.Students.Queries.Models
{
    public class GetStudentListQuery : IRequest<Response<List<GetStudentListResponse>>>
    {
    }
}
