using MediatR;
using SchoolSystem_Core.Features.Students.Queries.Response;
using SchoolSystem_Core.Wrapper;
using SchoolSystem_Data.Helper;

namespace SchoolSystem_Core.Features.Students.Queries.Models
{
	public class GetStudentPagintedListQuery : IRequest<PaginatedResult<GetStudentPagintedListResponse>>
	{
		public int PageNumber { get; set; }

		public int PageSize { get; set; }

		public StudentOrderingEnum OrderBy { get; set; }

		public string? Search { get; set; }

	}
}
