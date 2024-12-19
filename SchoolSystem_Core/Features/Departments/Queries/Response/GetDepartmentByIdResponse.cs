namespace SchoolSystem_Core.Features.Departments.Queries.Response
{
	public class GetDepartmentByIdResponse
	{
		public int Id { get; set; }

		public string? Name { get; set; }

		public string? ManagerName { get; set; }

		public List<StudentResponse>? StudentsList { get; set; }

		public List<SubjectResponse>? SubjectsList { get; set; }

		public List<InstructorsResponse>? InstructorsList { get; set; }
	}

	public class StudentResponse
	{
		public int Id { get; set; }
		public string? Name { get; set; }
	}

	public class SubjectResponse
	{
		public int Id { get; set; }
		public string? Name { get; set; }
	}

	public class InstructorsResponse
	{
		public int Id { get; set; }
		public string? Name { get; set; }
	}

}
