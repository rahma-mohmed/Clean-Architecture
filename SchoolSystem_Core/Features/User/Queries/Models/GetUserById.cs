using MediatR;
using SchoolSystem_Core.Basis;
using SchoolSystem_Core.Features.User.Queries.Result;

namespace SchoolSystem_Core.Features.User.Queries.Models
{
	public class GetUserById : IRequest<Response<GetUserByIdResponse>>
	{
		public int Id { get; set; }

		public GetUserById(int id)
		{
			Id = id;
		}
	}
}
