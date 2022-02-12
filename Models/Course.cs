using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        [StringLength(100, ErrorMessage = "Course Title cannot be longer than 100 characters."), RegularExpression(@"^[A-Za-z0-9'\s]*$", ErrorMessage = "No special characters!")]
        public string courseTitle { get; set; }
        [Required]
        [StringLength(500, ErrorMessage ="Course Information cannot be longer than 500 characters")]
        public string courseInfo { get; set; }
        [Required]
        public double? coursePrice { get; set; }
        [Required]
        public string courseGenre { get; set; }
        [Required]
        public bool courseFormat { get; set; }
        [NotMapped]
        public IFormFile courseImg { get; set; }
        [Required]
        public string? courseVideo { get; set; }
        [ForeignKey("User")]
        public int userID { get; set; }
        [Required]
        public bool approvalStatus { get; set; }

        public UserModel User { get; set; }
    }
}
