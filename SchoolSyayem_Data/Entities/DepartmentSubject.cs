﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem_Data.Entities
{
	public class DepartmentSubject
	{
		[Key]
		public int DID { get; set; }
		[Key]
		public int SubID { get; set; }

		[ForeignKey("DID")]
		[InverseProperty(nameof(Department.Departmentsubjects))]
		public virtual Department? Department { get; set; }

		[ForeignKey("SubID")]
		[InverseProperty(nameof(Subject.DepartmetsSubjects))]
		public virtual Subject? Subjects { get; set; }
	}
}