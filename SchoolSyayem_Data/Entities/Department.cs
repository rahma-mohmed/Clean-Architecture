using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem_Data.Entities
{
    public class Department
    {
        public Department()
        {
            Students = new HashSet<Student>();
            Departmentsubjects = new HashSet<DepartmentSubject>();
        }

        public int Id { get; set; }
        [StringLength(500)]
        public string DName { get; set; }
        [InverseProperty("Departments")]
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<DepartmentSubject> Departmentsubjects { get; set; }
    }
}