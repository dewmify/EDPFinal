using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EDPFinal.Models
{
    public class Teacher : User
    {   
        public int TeacherID { get; set; }
        [Required]
        public string TeacherName { get; set; }
        [Required]
        public string TeacherEmail { get; set; }
    }
}
