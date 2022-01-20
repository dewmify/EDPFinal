using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EDPFinal.Pages.Teacher
{
    public class DeleteCourseModel : PageModel
    {
        [BindProperty]
        public Course MyCourses { get; set; }
        private readonly ILogger<DeleteCourseModel> _logger;
        private readonly CourseService _svc;
        public DeleteCourseModel(ILogger<DeleteCourseModel> logger, CourseService service)
        {
            _logger = logger;
            _svc = service;
        }
        public IActionResult OnGet(int id)
        {
            if (id != null)
            {
                MyCourses = _svc.GetCourse(id);
            }
            else
            {
                return NotFound();
            }
            if (_svc.DeleteCourse(MyCourses))
            {
                return RedirectToPage("./CourseList");
            }
            return RedirectToPage("./CourseList");
        }
    }
}
