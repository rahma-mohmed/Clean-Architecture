using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolSystem_Core.Basis;
using SchoolSystem_Core.Features.Departments.Commands.Models;
using SchoolSystem_Core.SharedResources;
using SchoolSystem_Data.Entities;
using SchoolSystem_Service.IService;

namespace SchoolSystem_Core.Features.Departments.Commands.Handlers
{
	public class DepartmentCommandHandler : ResponseHandler,
		IRequestHandler<AddDepartmentCommand, Response<string>>,
		IRequestHandler<DeleteDepartmentCommand, Response<string>>,
		IRequestHandler<UpdateDepartmentCommand, Response<string>>
	{
		#region Fields
		private readonly IDepartmentService _departmentService;
		private readonly IMapper _mapper;
		private readonly IStringLocalizer<SharedResources.SharedResources> _stringLocalizer;

		public DepartmentCommandHandler(IMapper mapper, IDepartmentService departmentService, IStringLocalizer<SharedResources.SharedResources> stringLocalizer) : base(stringLocalizer)
		{
			_mapper = mapper;
			_departmentService = departmentService;
			_stringLocalizer = stringLocalizer;
		}

		public async Task<Response<string>> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
		{
			var Departmentmapper = _mapper.Map<Department>(request);
			var res = await _departmentService.AddAsync(Departmentmapper);
			if (res == "Success") return Created($"{_stringLocalizer[SharedResourcesKeys.Created]}");

			else return BadRequest<string>();
		}

		public async Task<Response<string>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
		{
			var department = await _departmentService.GetByIdAsync(request.Id);
			if (department == null) return NotFound<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);
			var res = await _departmentService.DeleteAsync(department);

			if (res == "Success") return Deleted<string>($"{_stringLocalizer[SharedResourcesKeys.DeletedSuccess]} {request.Id}");

			else return BadRequest<string>(res);//BadRequest<string>($"{_stringLocalizer[SharedResourcesKeys.DeletedFailed]}");
		}

		public async Task<Response<string>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
		{
			var department = await _departmentService.GetByIdAsync(request.Id);
			if (department == null) return NotFound<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);

			var departmentMapper = _mapper.Map<Department>(request);

			var res = await _departmentService.EditAsync(departmentMapper);

			if (res == "Success") return Success($"{_stringLocalizer[SharedResourcesKeys.UpdateSuccess]} {departmentMapper.Id}");

			else return BadRequest<string>();
		}
		#endregion
	}
}
