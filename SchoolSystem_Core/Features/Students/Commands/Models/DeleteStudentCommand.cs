﻿using MediatR;
using SchoolSystem_Core.Basis;

namespace SchoolSystem_Core.Features.Students.Commands.Models
{
	public class DeleteStudentCommand : IRequest<Response<string>>
	{
		public int Id { get; set; }

		public DeleteStudentCommand(int id)
		{
			Id = id;
		}
	}
}
