using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem_Data.Entities
{
	public class Ins_Subject
	{
		[Key]
		public int InsId { get; set; }

		[Key]
		public int SubID { get; set; }

		[ForeignKey("InsId")]
		[InverseProperty(nameof(Instructor.Ins_Subjects))]
		public Instructor? Instructor { get; set; }

		[ForeignKey("SubID")]
		[InverseProperty(nameof(Subject.Ins_Subjects))]
		public Subject? Subject { get; set; }
	}
}
