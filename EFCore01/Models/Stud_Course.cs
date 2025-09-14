using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore01.Models
{
    public class Stud_Course
    {
        [Key, Column(Order = 0)]
        public int stud_ID { get; set; }

        [Key, Column(Order = 1)]
        public int Course_ID { get; set; }

        public decimal Grade { get; set; }
    }
}
