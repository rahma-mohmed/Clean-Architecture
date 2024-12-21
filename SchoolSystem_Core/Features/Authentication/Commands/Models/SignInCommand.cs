using MediatR;
using SchoolSystem_Core.Basis;
using SchoolSystem_Data.Helper;

namespace SchoolSystem_Core.Features.Authentication.Commands.Models
{
	public class SignInCommand : IRequest<Response<JwtAuthResult>>
	{
		public string UserName { get; set; }
		public string Password { get; set; }
	}
}
