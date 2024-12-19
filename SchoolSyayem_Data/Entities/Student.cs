using SchoolSystem_Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem_Data.Entities
{
	public class Student : GeneralLocalizableEntity
	{
		public Student()
		{
			StudentSubjects = new HashSet<StudentSubject>();
		}

		public int Id { get; set; }

		[StringLength(100)]
		public string? NameAr { get; set; }

		[StringLength(100)]
		public string? NameEn { get; set; }

		[StringLength(100)]
		public string? AddressAr { get; set; }

		[StringLength(100)]
		public string? AddressEn { get; set; }

		public string? Phone { get; set; }

		public int? DID { get; set; }

		[ForeignKey("DID")]
		[InverseProperty("Students")]
		public virtual Department? Departments { get; set; }

		[InverseProperty(nameof(StudentSubject.Student))]
		public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
	}
}
