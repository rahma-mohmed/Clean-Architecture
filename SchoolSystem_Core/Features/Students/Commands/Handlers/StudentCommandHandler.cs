using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolSystem_Core.Basis;
using SchoolSystem_Core.Features.Students.Commands.Models;
using SchoolSystem_Core.SharedResources;
using SchoolSystem_Data.Entities;
using SchoolSystem_Service.IService;

namespace SchoolSystem_Core.Features.Students.Commands.Handlers
{
	public class StudentCommandHandler : ResponseHandler,
		IRequestHandler<AddStudentCommand, Response<string>>,
		IRequestHandler<EditStudentCommand, Response<string>>,
		IRequestHandler<DeleteStudentCommand, Response<string>>


	{
		#region Fields
		private readonly IStudentService _studentService;
		private readonly IMapper _mapper;
		private readonly IStringLocalizer<SharedResources.SharedResources> _stringLocalizer;
		#endregion

		#region Constructor
		public StudentCommandHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResources.SharedResources> stringLocalizer) : base(stringLocalizer)
		{
			_studentService = studentService;
			_mapper = mapper;
			_stringLocalizer = stringLocalizer;
		}
		#endregion

		#region Handle Function 
		public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
		{
			//map between request & student
			var studentmapper = _mapper.Map<Student>(request);
			//add
			var res = await _studentService.AddAsync(studentmapper);
			//check errors

			//if (res == "Exist") return UnProcessableEntity<string>("User Name Is Exist");

			if (res == "Success") return Created($"{_stringLocalizer[SharedResourcesKeys.Created]}");

			else return BadRequest<string>();
		}

		public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
		{
			//check if id is exist
			var std = await _studentService.GetByIdAsync(request.Id);
			if (std == null) return NotFound<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);

			var studentmapper = _mapper.Map<Student>(request);

			//call service
			var res = await _studentService.EditAsync(studentmapper);

			if (res == "Success") return Success($"{_stringLocalizer[SharedResourcesKeys.UpdateSuccess]} {studentmapper.Id}");

			else return BadRequest<string>();

		}

		public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
		{
			var std = await _studentService.GetByIdAsync(request.Id);
			if (std == null) return NotFound<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);
			var res = await _studentService.DeleteAsync(std);

			if (res == "Success") return Deleted<string>($"{_stringLocalizer[SharedResourcesKeys.DeletedSuccess]} {request.Id}");

			else return BadRequest<string>();
		}
		#endregion
	}
}
