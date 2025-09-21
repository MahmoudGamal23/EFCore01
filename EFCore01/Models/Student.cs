using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore01.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }

        [Required, MaxLength(50)]
        public string FName { get; set; }

        [Required, MaxLength(50)]
        public string LName { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        public int Age { get; set; }

        public int Dep_Id { get; set; }
        public Department Department { get; set; }
        public List<Stud_Course> Stud_Courses { get; set; } = new();
    }
}