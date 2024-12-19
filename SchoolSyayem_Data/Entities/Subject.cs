using SchoolSystem_Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem_Data.Entities
{
	public class Subject : GeneralLocalizableEntity
	{
		public Subject()
		{
			StudentsSubjects = new HashSet<StudentSubject>();
			DepartmetsSubjects = new HashSet<DepartmentSubject>();
			Ins_Subjects = new HashSet<Ins_Subject>();
		}

		[Key]
		public int SubID { get; set; }
		[StringLength(100)]
		public string? SubjectNameAr { get; set; }
		[StringLength(100)]
		public string? SubjectNameEn { get; set; }
		public DateTime? Period { get; set; }

		[InverseProperty(nameof(StudentSubject.Subject))]
		public virtual ICollection<StudentSubject> StudentsSubjects { get; set; }

		[InverseProperty(nameof(DepartmentSubject.Subjects))]
		public virtual ICollection<DepartmentSubject> DepartmetsSubjects { get; set; }

		[InverseProperty(nameof(Ins_Subject.Subject))]
		public virtual ICollection<Ins_Subject> Ins_Subjects { get; set; }
	}
}
