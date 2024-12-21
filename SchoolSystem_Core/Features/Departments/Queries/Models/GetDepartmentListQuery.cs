using MediatR;
using SchoolSystem_Core.Features.Departments.Queries.Response;
using SchoolSystem_Core.Wrapper;
using SchoolSystem_Data.Helper;

namespace SchoolSystem_Core.Features.Departments.Queries.Models
{
	public class GetDepartmentListQuery : IRequest<PaginatedResult<GetDepartmentListResponse>>
	{
		public int PageSize { get; set; }
		public int PageNumber { get; set; }

		public DepartmentOrderingEnum OrderBy { get; set; }

		public string? Search { get; set; }
	}
}
