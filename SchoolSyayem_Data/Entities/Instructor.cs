using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem_Data.Entities
{
	public class Instructor
	{
		public Instructor()
		{

			Instructors = new HashSet<Instructor>();
			Ins_Subjects = new HashSet<Ins_Subject>();
		}

		[Key]
		public int InsId { get; set; }

		public string? INameAr { get; set; }

		public string? INameEn { get; set; }

		public string? Address { get; set; }

		public string? Position { get; set; }

		public int? SupervisorId { get; set; }

		public decimal? Salary { get; set; }

		public int? DID { get; set; }

		[ForeignKey(nameof(DID))]
		[InverseProperty(nameof(Department.Instructors))]
		public Department? Department { get; set; }

		[InverseProperty(nameof(Department.Instructor))]
		public Department? DepartmentManager { get; set; }

		[ForeignKey(nameof(SupervisorId))]
		[InverseProperty(nameof(Instructors))]
		public Instructor? Supervisor { get; set; }

		[InverseProperty(nameof(Supervisor))]
		public virtual ICollection<Instructor>? Instructors { get; set; }

		[InverseProperty(nameof(Ins_Subject.Instructor))]
		public virtual ICollection<Ins_Subject>? Ins_Subjects { get; set; }
	}
}
