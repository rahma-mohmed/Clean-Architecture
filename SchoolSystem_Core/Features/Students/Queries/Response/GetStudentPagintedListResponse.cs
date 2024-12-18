namespace SchoolSystem_Core.Features.Students.Queries.Response
{
	public class GetStudentPagintedListResponse
	{
		public int Id { get; set; }

		public string? Name { get; set; }

		public string? Address { get; set; }

		public string? DepartmentName { get; set; }

		public GetStudentPagintedListResponse(int id, string name, string address, string deptName)
		{
			Id = id;
			Name = name;
			Address = address;
			DepartmentName = deptName;
		}
	}
}
