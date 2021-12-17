using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDPFinal.Models
{
    public class Course
    {
        public int courseID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Course Title cannot be longer than 100 characters.")]
        public string courseTitle { get; set; }
        [StringLength(300, ErrorMessage ="Course Information cannot be longer than 500 characters")]
        public string courseInfo { get; set; }
        [Required]
        public int coursePrice { get; set; }
        [Required]
        public string courseGenre { get; set; }
        [Required]
        public bool courseFormat { get; set; }
    }
}
