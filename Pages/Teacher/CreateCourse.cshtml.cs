using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDPFinal.Pages.Teacher
{
    public class CreateCourseModel : PageModel
    {
        private readonly CourseService _svc;
        public CreateCourseModel(CourseService service)
        {
            _svc = service;
        }
        [BindProperty]
        public Course MyCourses { get; set; }
        
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                return Page();
                /*if (_svc.AddCourse(MyCourses))
                {
                    return RedirectToPage("");
                }*/
                    
            }
            return Page();
        }
    }
}
