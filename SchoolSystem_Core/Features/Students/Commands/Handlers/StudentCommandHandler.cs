using AutoMapper;
using MediatR;
using SchoolSystem_Core.Basis;
using SchoolSystem_Core.Features.Students.Commands.Models;
using SchoolSystem_Data.Entities;
using SchoolSystem_Service.Implementations;

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
		#endregion

		#region Constructor
		public StudentCommandHandler(IStudentService studentService, IMapper mapper)
		{
			_studentService = studentService;
			_mapper = mapper;
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

			if (res == "Success") return Created("Added Successfully");

			else return BadRequest<string>();
		}

		public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
		{
			//check if id is exist
			var std = await _studentService.GetByIdAsync(request.Id);
			if (std == null) return NotFound<string>("Student is not found");
			var studentmapper = _mapper.Map<Student>(request);

			//call service
			var res = await _studentService.EditAsync(studentmapper);

			if (res == "Success") return Success($"Student updated successfully {studentmapper.Id}");

			else return BadRequest<string>();

		}

		public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
		{
			var std = await _studentService.GetByIdAsync(request.Id);
			if (std == null) return NotFound<string>("Student is not found");
			var res = await _studentService.DeleteAsync(std);

			if (res == "Success") return Deleted<string>($"Student deleted successfully {request.Id}");

			else return BadRequest<string>();
		}
		#endregion
	}
}
