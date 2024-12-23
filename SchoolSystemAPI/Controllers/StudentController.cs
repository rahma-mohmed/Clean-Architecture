﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem_Core.Features.Students.Commands.Models;
using SchoolSystem_Core.Features.Students.Queries.Models;
using SchoolSystem_Data.AppMetaData;
using SchoolSystemAPI.Base;

namespace SchoolSystemAPI.Controllers
{
	[ApiController]
	public class StudentController : AppControllerBase
	{
		[Authorize]
		[HttpGet(Router.StudentRouting.List)]
		public async Task<ActionResult> GetStudentTask()
		{
			var response = await Mediator.Send(new GetStudentListQuery());
			return NewResult(response);
		}

		[Authorize]
		[HttpGet(Router.StudentRouting.Paginated)]
		public async Task<ActionResult> Paginated([FromQuery] GetStudentPagintedListQuery query)
		{
			var response = await Mediator.Send(query);
			return Ok(response);
		}

		[HttpGet(Router.StudentRouting.GetById)]
		public async Task<ActionResult> GetStudentByIdTask([FromRoute] int id)
		{
			var response = await Mediator.Send(new GetStudentByIdQuery(id));
			return NewResult(response);
		}

		[HttpPost(Router.StudentRouting.Create)]
		public async Task<ActionResult> Create([FromBody] AddStudentCommand command)
		{
			var response = await Mediator.Send(command);
			return NewResult(response);
		}

		[HttpDelete(Router.StudentRouting.Delete)]
		public async Task<ActionResult> Delete([FromRoute] int id)
		{
			var response = await Mediator.Send(new DeleteStudentCommand(id));
			return NewResult(response);
		}

		[HttpPut(Router.StudentRouting.Edit)]
		public async Task<ActionResult> Edit([FromBody] EditStudentCommand command)
		{
			var response = await Mediator.Send(command);
			return NewResult(response);
		}
	}
}
