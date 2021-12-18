using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDPFinal.Models
{
    public class Review
    {
        [Required]
        [StringLength(100, ErrorMessage = "Course Title cannot be longer than 100 characters.")]
        public string reviewTitle { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage ="Course Information cannot be longer than 1000 characters")]
        public string reviewDescription { get; set;}

        [Required]
        [StringLength(100, ErrorMessage ="Course Information cannot be longer than 100 characters")]
        public string lecturerName  { get; set; }

        public List<Review> reviews { get; set; }

        public int numberOfReviews  { get; set; }
    }
}
