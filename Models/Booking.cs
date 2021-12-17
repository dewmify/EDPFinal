using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EDPFinal.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public DateTime BookingTime { get; set; }
        //CourseID from Course model
        public int CourseID { get; set; }
        //StudentID from Student model
        public int StudentID { get; set; }
    }
}
