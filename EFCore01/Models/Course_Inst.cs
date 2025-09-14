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
        [Key, Column(Order = 0)]
        public int inst_ID { get; set; }

        [Key, Column(Order = 1)]
        public int Course_ID { get; set; }

        [MaxLength(20)]
        public string Evaluate { get; set; }
    }
}
