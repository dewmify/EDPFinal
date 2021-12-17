using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EDPFinal.Models
{
    public class Teacher
    {
        public int userID { get; set; }
        public string userEmail { get; set; }
        public string userName { get; set; }
        
        public int TeacherID { get; set; }
        [Required]
        public string TeacherName { get; set; }
        [Required]
        public string TeacherEmail { get; set; }
    }
}
