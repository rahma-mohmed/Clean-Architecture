using Microsoft.AspNetCore.Mvc;
using SchoolSystem_Core.Features.Authentication.Commands.Models;
using SchoolSystem_Data.AppMetaData;
using SchoolSystemAPI.Base;

namespace SchoolSystemAPI.Controllers
{
	[ApiController]
	public class AuthenticationController : AppControllerBase
	{
		[HttpPost(Router.AuthenticationRouting.SignIn)]
		public async Task<ActionResult> SignIn([FromForm] SignInCommand command)
		{
			var response = await Mediator.Send(command);
			return NewResult(response);
		}

		[HttpPost(Router.AuthenticationRouting.RefreshToken)]
		public async Task<ActionResult> RefreshToken([FromForm] RefreshTokenCommand command)
		{
			var response = await Mediator.Send(command);
			return NewResult(response);
		}
	}
}
