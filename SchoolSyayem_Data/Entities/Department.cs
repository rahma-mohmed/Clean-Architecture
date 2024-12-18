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
		}

		public int Id { get; set; }
		[StringLength(100)]
		public string DNameAr { get; set; }
		[StringLength(100)]
		public string DNameEn { get; set; }
		[InverseProperty("Departments")]
		public virtual ICollection<Student> Students { get; set; }
		public virtual ICollection<DepartmentSubject> Departmentsubjects { get; set; }
	}
}