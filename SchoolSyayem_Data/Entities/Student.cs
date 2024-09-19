using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem_Data.Entities
{
    public class Student
    {
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; }    
        [StringLength(500)]
        public string Address { get; set; } 
        public string Phone { get; set; }
        public int? DID { get; set; }
        [ForeignKey("DID")]
        [InverseProperty("Students")]
        public virtual Department Departments { get; set; }
    }
}
