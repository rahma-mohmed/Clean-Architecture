﻿using Microsoft.AspNetCore.Mvc;
using SchoolSystem_Core.Features.User.Commands.Models;
using SchoolSystem_Data.AppMetaData;
using SchoolSystemAPI.Base;

namespace SchoolSystemAPI.Controllers
{
	[ApiController]
	public class UserController : AppControllerBase
	{
		[HttpPost(Router.UserRouting.Create)]
		public async Task<IActionResult> Create([FromBody] AddUserCommand command)
		{
			var response = await Mediator.Send(command);
			return NewResult(response);
		}
	}
}
