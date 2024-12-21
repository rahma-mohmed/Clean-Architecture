using Microsoft.AspNetCore.Mvc;
using SchoolSystem_Core.Features.User.Commands.Models;
using SchoolSystem_Core.Features.User.Queries.Models;
using SchoolSystem_Data.AppMetaData;
using SchoolSystemAPI.Base;

namespace SchoolSystemAPI.Controllers
{
	[ApiController]
	public class UserController : AppControllerBase
	{
		[HttpGet(Router.UserRouting.Paginated)]
		public async Task<ActionResult> Paginated([FromQuery] GetUserListQuery query)
		{
			var response = await Mediator.Send(query);
			return Ok(response);
		}

		[HttpGet(Router.UserRouting.GetById)]
		public async Task<ActionResult> GetUserByIdTask([FromRoute] int id)
		{
			var response = await Mediator.Send(new GetUserById(id));
			return NewResult(response);
		}

		[HttpPost(Router.UserRouting.Create)]
		public async Task<IActionResult> Create([FromBody] AddUserCommand command)
		{
			var response = await Mediator.Send(command);
			return NewResult(response);
		}

		[HttpDelete(Router.UserRouting.Delete)]
		public async Task<ActionResult> Delete([FromRoute] int id)
		{
			var response = await Mediator.Send(new DeleteUserCommand(id));
			return NewResult(response);
		}

		[HttpPut(Router.UserRouting.Edit)]
		public async Task<ActionResult> Edit([FromBody] UpdateUserCommand command)
		{
			var response = await Mediator.Send(command);
			return NewResult(response);
		}

		[HttpPut(Router.UserRouting.Password)]
		public async Task<ActionResult> ChangePassword([FromForm] ChangeUserPasswordCommand command)
		{
			var response = await Mediator.Send(command);
			return NewResult(response);
		}
	}
}
