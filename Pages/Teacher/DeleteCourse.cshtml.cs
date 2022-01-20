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
    public class DeleteCourseModel : PageModel
    {
        [BindProperty]
        public Course MyCourses { get; set; }
        private readonly CourseService _svc;
        public DeleteCourseModel(CourseService service)
        {
            _svc = service;
        }
        public IActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //MyCourses = _svc.DeleteCourse(id);
            if (MyCourses == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
