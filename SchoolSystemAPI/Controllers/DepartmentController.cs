using Microsoft.AspNetCore.Mvc;
using SchoolSystem_Core.Features.Departments.Queries.Models;
using SchoolSystem_Data.AppMetaData;
using SchoolSystemAPI.Base;

namespace SchoolSystemAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentController : AppControllerBase
	{
		[HttpGet(Router.DepartmentRouting.GetById)]
		public async Task<ActionResult> GetDepartmentByIdTask([FromRoute] int id)
		{
			var response = await Mediator.Send(new GetDepartmentByIdQuery(id));
			return NewResult(response);
		}
	}
}
