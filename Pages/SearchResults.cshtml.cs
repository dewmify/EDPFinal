using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDPFinal.Pages
{
    public class SearchResultsModel : PageModel
    {
        /*private readonly CourseService _context;

        public IList<Course> Course;
        public async Task<IActionResult> SearchResults(string searchString)
        {
            var courses = from c in _context.Course
                          select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                courses = courses.Where(s => s.courseTitle!.Contains(searchString));
            }

            Course = await courses.ToListAsync();
            return  View(await courses.ToListAsync());

        }

        public void OnGet()
        {
        }*/
    }
}
