using MediatR;
using SchoolSystem_Core.Basis;

namespace SchoolSystem_Core.Features.Departments.Commands.Models
{
	public class UpdateDepartmentCommand : IRequest<Response<string>>
	{
		public int Id { get; set; }

		public string? DNameAr { get; set; }

		public string? DNameEn { get; set; }

		public int? InsManager { get; set; }
	}
}
