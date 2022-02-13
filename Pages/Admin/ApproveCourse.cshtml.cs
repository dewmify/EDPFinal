using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EDPFinal.Pages.Admin
{
    public class ApproveCourseModel : PageModel
    {
        private readonly ILogger<ApproveCourseModel> _logger;
        private readonly CourseService _svc;
        public ApproveCourseModel(ILogger<ApproveCourseModel> logger, CourseService service)
        {
            _logger = logger;
            _svc = service;
        }
        [BindProperty]

        public Course MyCourse { get; set; }
        public IActionResult OnGet(int id)
        {
            if (id != null)
            {
                MyCourse = _svc.GetCourse(id);
            }
            else
                return RedirectToPage("./UnapprovedCourses");

            MyCourse.approvalStatus = true;

            if (_svc.UpdateCourse(MyCourse))
            {
                return RedirectToPage("./UnapprovedCourses");
            }
            else
            {
                return Page();
            }
        }
    }
}
