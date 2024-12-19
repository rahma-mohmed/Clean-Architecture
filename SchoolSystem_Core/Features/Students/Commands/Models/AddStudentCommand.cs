using MediatR;
using SchoolSystem_Core.Basis;

namespace SchoolSystem_Core.Features.Students.Commands.Models
{
	public class AddStudentCommand : IRequest<Response<string>>
	{
		public string? NameAr { get; set; }

		public string? NameEn { get; set; }

		public string? AddressAr { get; set; }

		public string? AddressEn { get; set; }

		public string? Phone { get; set; }

		public int DepartmentId { get; set; }
	}
}
