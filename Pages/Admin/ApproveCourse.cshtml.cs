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

namespace EDPFinal.Pages.Admin
{
    public class ApproveCourseModel : PageModel
    {
        [BindProperty]
        public List<Course> AllCourses { get; set; }
        private readonly ILogger<ApproveCourseModel> _logger;
        private CourseService _svc;

        public ApproveCourseModel(ILogger<ApproveCourseModel> logger, CourseService service)
        {
            _logger = logger;
            _svc = service;
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("userType") != "admin")
            {
                return RedirectToPage("../Index");
            }
            AllCourses = _svc.GetAllCourses();
            return Page();
        }
    }
}
