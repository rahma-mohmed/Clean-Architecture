using MediatR;
using SchoolSystem_Core.Basis;

namespace SchoolSystem_Core.Features.Authorization.Commands.Models
{
	public class AddRolesCommands : IRequest<Response<string>>
	{
		public string RoleName { get; set; }
	}
}
