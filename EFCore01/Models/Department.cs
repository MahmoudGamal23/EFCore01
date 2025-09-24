using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore01.Models
{
    public class Department
    {
        [Key]
        public int ID { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public int? Ins_ID { get; set; }

        public DateTime HiringDate { get; set; }

        public virtual Instructor Manager { get; set; }
        public virtual List<Student> Students { get; set; } = new();
        public virtual List<Instructor> Instructors { get; set; } = new();
        public virtual List<Employee> Employees { get; set; } = new();
    }
}

