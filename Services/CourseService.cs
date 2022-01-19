using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDPFinal.Models;

namespace EDPFinal.Services
{
    public class CourseService
    {
        private Models.CourseDbContext _context;
        public CourseService(Models.CourseDbContext context)
        {
            _context = context;
        }

        public bool AddCourse(Course newcourse)
        {
            //if (CourseExists(newcourse.courseID))
            //{
            //    return false;
            //}
            _context.Add(newcourse);
            _context.SaveChanges();
            return true;
        }
    }
}
