using MediatR;
using SchoolSystem_Core.Basis;

namespace SchoolSystem_Core.Features.User.Commands.Models
{
	public class UpdateUserCommand : IRequest<Response<string>>
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
		public string Email { get; set; }
		public string? Address { get; set; }
		public string? Country { get; set; }
		public string? PhoneNumber { get; set; }
	}
}
