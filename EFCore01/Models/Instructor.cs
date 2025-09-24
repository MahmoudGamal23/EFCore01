using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore01.Models
{
    public class Instructor
    {
        [Key]
        public int ID { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public decimal Salary { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        public decimal HourRate { get; set; }

        public decimal Bonus { get; set; }

        public int Dept_ID { get; set; }

        public virtual Department Department { get; set; }
        public virtual List<Course_Inst> Course_Insts { get; set; } = new();
    }
}
