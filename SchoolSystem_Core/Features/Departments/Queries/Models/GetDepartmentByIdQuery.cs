using MediatR;
using SchoolSystem_Core.Basis;
using SchoolSystem_Core.Features.Departments.Queries.Response;

namespace SchoolSystem_Core.Features.Departments.Queries.Models
{
	public class GetDepartmentByIdQuery : IRequest<Response<GetDepartmentByIdResponse>>
	{
		public int Id { get; set; }

		public GetDepartmentByIdQuery(int id)
		{
			Id = id;
		}
	}
}
