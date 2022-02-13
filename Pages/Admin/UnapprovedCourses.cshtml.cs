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
    public class UnapprovedCoursesModel : PageModel
    {
        [BindProperty]
        public List<Course> AllCourses { get; set; }

        public Course MyCourses { get; set; }
        private readonly ILogger<UnapprovedCoursesModel> _logger;
        private CourseService _svc;



        public UnapprovedCoursesModel(ILogger<UnapprovedCoursesModel> logger, CourseService service)
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

        public IActionResult OnPost()
        {
            MyCourses = _svc.GetCourse(MyCourses.courseID);
            if (ModelState.IsValid)
            {
                MyCourses.approvalStatus = true;
                return RedirectToPage("/ApprovedCourseConfirmed") ;
            }
            return RedirectToPage("");
        }
    }
}
