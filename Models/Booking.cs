using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDPFinal.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingID { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BookingTime { get; set; }
        [ForeignKey("Course")]
        public int CourseID { get; set; }
        [ForeignKey("User")]
        public int StudentID { get; set; }
        public Course Course { get; set; }
        public UserModel User { get; set; }
    }
}
