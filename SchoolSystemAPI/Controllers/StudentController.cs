using Microsoft.AspNetCore.Mvc;
using SchoolSystem_Core.Features.Students.Commands.Models;
using SchoolSystem_Core.Features.Students.Queries.Models;
using SchoolSystem_Data.AppMetaData;
using SchoolSystemAPI.Base;

namespace SchoolSystemAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : AppControllerBase
	{
		[HttpGet(Router.StudentRouting.List)]
		public async Task<ActionResult> GetStudentTask()
		{
			var response = await Mediator.Send(new GetStudentListQuery());
			return NewResult(response);
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

		[HttpPut(Router.StudentRouting.Edit)]
		public async Task<ActionResult> Edit([FromBody] EditStudentCommand command)
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
	}
}
