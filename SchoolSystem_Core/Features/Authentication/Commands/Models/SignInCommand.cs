using MediatR;
using SchoolSystem_Core.Basis;

namespace SchoolSystem_Core.Features.Authentication.Commands.Models
{
	public class SignInCommand : IRequest<Response<string>>
	{
		public string UserName { get; set; }
		public string Password { get; set; }
	}
}
