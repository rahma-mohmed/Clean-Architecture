using SchoolSystem_Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem_Data.Entities
{
	public class Department : GeneralLocalizableEntity
	{
		public Department()
		{
			Students = new HashSet<Student>();
			Departmentsubjects = new HashSet<DepartmentSubject>();
			Instructors = new HashSet<Instructor>();
		}

		public int Id { get; set; }

		[StringLength(100)]
		public string? DNameAr { get; set; }

		[StringLength(100)]
		public string? DNameEn { get; set; }

		public int? InsManager { get; set; }

		[InverseProperty(nameof(Student.Departments))]
		public virtual ICollection<Student> Students { get; set; }

		[InverseProperty(nameof(DepartmentSubject.Department))]
		public virtual ICollection<DepartmentSubject> Departmentsubjects { get; set; }

		[InverseProperty(nameof(Instructor.Department))]
		public virtual ICollection<Instructor> Instructors { get; set; }

		[ForeignKey(nameof(InsManager))]
		[InverseProperty(nameof(Instructor.DepartmentManager))]
		public virtual Instructor? Instructor { get; set; }
	}
}