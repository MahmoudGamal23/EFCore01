using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore01.Models
{
    public class Course_Inst
    {
        public int inst_ID { get; set; }
        public int Course_ID { get; set; }

        [MaxLength(20)]
        public string Evaluate { get; set; }

        public virtual Instructor Instructor { get; set; }
        public virtual Course Course { get; set; }
    }
}
