using MediatR;
using SchoolSystem_Core.Basis;

namespace SchoolSystem_Core.Features.User.Commands.Models
{
	public class DeleteUserCommand : IRequest<Response<string>>
	{
		public int Id { get; set; }

		public DeleteUserCommand(int id)
		{
			Id = id;
		}
	}
}
