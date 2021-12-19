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
        public int BookingID { get; set; }

        public DateTime BookingTime { get; set; }
        //CourseID from Course model
        [ForeignKey("")]
        public int CourseID { get; set; }
        //StudentID from Student model
        [ForeignKey("")]
        public int StudentID { get; set; }
    }
}
