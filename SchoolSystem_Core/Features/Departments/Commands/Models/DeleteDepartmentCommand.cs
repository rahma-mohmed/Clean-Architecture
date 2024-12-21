using MediatR;
using SchoolSystem_Core.Basis;

namespace SchoolSystem_Core.Features.Departments.Commands.Models
{
	public class DeleteDepartmentCommand : IRequest<Response<string>>
	{
		public int Id { get; set; }

		public DeleteDepartmentCommand(int id)
		{
			Id = id;
		}
	}
}
