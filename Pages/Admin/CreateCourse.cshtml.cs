using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDPFinal.Pages.Admin
{
    public class CreateCourseModel : PageModel
    {
        [BindProperty]
        public Course MyCourses { get; set; }
        private readonly CourseService _svc;
        public CreateCourseModel(CourseService service)
        {
            _svc = service;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (_svc.AddCourse(MyCourses))
                {
                    return RedirectToPage("");
                }

            }
            return Page();
        }

        public void OnGet()
        {
        }
    }
}
