using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDPFinal.Models;
using Microsoft.EntityFrameworkCore;

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
            if (CourseExists(newcourse.courseID))
            {
                return false;
            }

            _context.Add(newcourse);
            _context.SaveChanges();
            return true;
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.courseID == id);
        }

        public Course GetCourse(int id)
        {
            var cor = _context.Courses.SingleOrDefault(o => o.courseID == id);
            return cor;
        }

        public List<Course> GetAllCourses()
        {
            List<Course> AllCourses = new List<Course>();
            AllCourses = _context.Courses.ToList();
            return AllCourses;
        }

        public bool UpdateCourse(Course thecourse)
        {
            bool updated = true;
            _context.Attach(thecourse).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
                updated = true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(thecourse.courseID))
                {
                    updated = false;
                }
                else
                {
                    throw;
                }
            }
            return updated;
        }

        public bool DeleteCourse(Course thecourse)
        {
            bool deleted = true;

            try
            {
                _context.Remove(thecourse);
                _context.SaveChanges();
                deleted = true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(thecourse.courseID))
                {
                    deleted = false;
                }
                else
                {
                    throw;
                }
            }
            return deleted;
        }
    }
}
