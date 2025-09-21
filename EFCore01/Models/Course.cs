using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore01.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }

        public int Duration { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public int Top_ID { get; set; }
        public Topic Topic { get; set; }
        public List<Stud_Course> Stud_Courses { get; set; } = new();
        public List<Course_Inst> Course_Insts { get; set; } = new();
    }
}
