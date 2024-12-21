using MediatR;
using SchoolSystem_Core.Basis;

namespace SchoolSystem_Core.Features.User.Commands.Models
{
	public class ChangeUserPasswordCommand : IRequest<Response<String>>
	{
		public int Id { get; set; }
		public string OldPassword { get; set; }
		public string NewPassword { get; set; }
		public string ConfirmNewPassword { get; set; }
	}
}
