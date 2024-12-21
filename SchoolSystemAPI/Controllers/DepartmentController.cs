using Microsoft.AspNetCore.Mvc;
using SchoolSystem_Core.Features.Departments.Commands.Models;
using SchoolSystem_Core.Features.Departments.Queries.Models;
using SchoolSystem_Data.AppMetaData;
using SchoolSystemAPI.Base;

namespace SchoolSystemAPI.Controllers
{
	[ApiController]
	public class DepartmentController : AppControllerBase
	{
		[HttpGet(Router.DepartmentRouting.GetById)]
		public async Task<ActionResult> GetDepartmentByIdTask([FromRoute] int id)
		{
			var response = await Mediator.Send(new GetDepartmentByIdQuery(id));
			return NewResult(response);
		}

		[HttpGet(Router.DepartmentRouting.Paginated)]
		public async Task<ActionResult> Paginated([FromQuery] GetDepartmentListQuery query)
		{
			var response = await Mediator.Send(query);
			return Ok(response);
		}

		[HttpPost(Router.DepartmentRouting.Create)]
		public async Task<ActionResult> Create([FromBody] AddDepartmentCommand command)
		{
			var response = await Mediator.Send(command);
			return NewResult(response);
		}

		[HttpDelete(Router.DepartmentRouting.Delete)]
		public async Task<ActionResult> Delete([FromRoute] int id)
		{
			var response = await Mediator.Send(new DeleteDepartmentCommand(id));
			return NewResult(response);
		}

		[HttpPut(Router.DepartmentRouting.Edit)]
		public async Task<ActionResult> Edit([FromBody] UpdateDepartmentCommand command)
		{
			var response = await Mediator.Send(command);
			return NewResult(response);
		}
	}
}
