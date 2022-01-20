using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EDPFinal.Models

{

    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int courseID { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Course Title cannot be longer than 100 characters.")]
        public string courseTitle { get; set; }
        [StringLength(500, ErrorMessage ="Course Information cannot be longer than 500 characters")]
        public string courseInfo { get; set; }
        [Required]
        public double coursePrice { get; set; }
        [Required]
        public string courseGenre { get; set; }
        [Required]
        public bool courseFormat { get; set; }
    }
}
