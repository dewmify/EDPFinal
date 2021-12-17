using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDPFinal.Models
{
    public class Course
    {
        public int courseID { get; set; }
        public string courseTitle { get; set; }
        public string courseInfo { get; set; }
        public int coursePrice { get; set; }
        public string courseGenre { get; set; }
        public bool courseFormat { get; set; }
    }
}
