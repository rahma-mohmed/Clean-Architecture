using AutoMapper;
using MediatR;
using SchoolSystem_Core.Basis;
using SchoolSystem_Core.Features.Students.Commands.Models;
using SchoolSystem_Data.Entities;
using SchoolSystem_Service.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem_Core.Features.Students.Commands.Handlers
{
	public class StudentCommandHandler : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>
	{
		#region Fields
		private readonly IStudentService _studentService;
		private readonly IMapper _mapper;
		#endregion

		#region Constructor
		public StudentCommandHandler(IStudentService studentService , IMapper mapper)
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

			if (res == "Exist") return UnProcessableEntity<string>("User Name Is Exist");

			else if (res == "Success") return Created("Added Successfully");

			else return BadRequest<string>();
		}
		#endregion
	}
}
