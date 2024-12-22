using MediatR;
using SchoolSystem_Core.Basis;
using SchoolSystem_Data.Helper;

namespace SchoolSystem_Core.Features.Authentication.Commands.Models
{
	public class RefreshTokenCommand : IRequest<Response<JwtAuthResult>>
	{
		public string AccessToken { get; set; }
		public string RefreshToken { get; set; }
	}
}
