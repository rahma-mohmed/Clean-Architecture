using SchoolSystem_Data.Commons;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystem_Data.Entities
{
	public class Subject : GeneralLocalizableEntity
	{
		public Subject()
		{
			StudentsSubjects = new HashSet<StudentSubject>();
			DepartmetsSubjects = new HashSet<DepartmentSubject>();
		}
		[Key]
		public int SubID { get; set; }
		[StringLength(100)]
		public string SubjectNameAr { get; set; }
		[StringLength(100)]
		public string SubjectNameEn { get; set; }
		public DateTime Period { get; set; }
		public virtual ICollection<StudentSubject> StudentsSubjects { get; set; }
		public virtual ICollection<DepartmentSubject> DepartmetsSubjects { get; set; }
	}
}
