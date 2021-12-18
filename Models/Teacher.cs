using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EDPFinal.Models
{
    public class Teacher : User
    {   
        [Required]
        public bool teacherStatus { get; set; }

        [Required]
        public bool registrationStatus { get; set; }

        [Required]
        public bool creationStatus { get; set; }

        [Required]
        public bool contentRevStatus { get; set; }
    }
}
