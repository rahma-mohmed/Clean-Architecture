using MediatR;
using SchoolSystem_Core.Features.User.Queries.Result;
using SchoolSystem_Core.Wrapper;

namespace SchoolSystem_Core.Features.User.Queries.Models
{
	public class GetUserListQuery : IRequest<PaginatedResult<GetUserListResponse>>
	{
		public int pageNumber { get; set; }
		public int pageSize { get; set; }
	}
}
