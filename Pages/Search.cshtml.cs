using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EDPFinal.Pages
{
    public class SearchResultsModel : PageModel
    {
        private readonly CourseDbContext _context;

        public SearchResultsModel(CourseDbContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get; set; }

        [BindProperty(SupportsGet = true)]
        public string searchString { get; set; }
        public SelectList Genres { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string courseGenre { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from c in _context.Course
                                            orderby c.courseGenre
                                            select c.courseGenre;

            var courses = from c in _context.Course
                          select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                courses = courses.Where(s => s.courseTitle.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(courseGenre))
            {
                courses = courses.Where(x => x.courseGenre == courseGenre);
            }

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Course = await courses.ToListAsync();
        }
        public void OnGet()
        {
        }
    }
}
