using Microsoft.AspNetCore.Mvc;
using SchoolSystem_Core.Features.Authorization.Commands.Models;
using SchoolSystem_Data.AppMetaData;
using SchoolSystemAPI.Base;

namespace SchoolSystemAPI.Controllers
{
	[ApiController]
	public class AuthorizationController : AppControllerBase
	{
		[HttpPost(Router.AuthorizationsRouting.AddRoles)]
		public async Task<ActionResult> AddRoles([FromForm] AddRolesCommands command)
		{
			var response = await Mediator.Send(command);
			return NewResult(response);
		}
	}
}
