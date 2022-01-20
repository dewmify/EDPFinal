using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EDPFinal.Pages.CourseBookings
{
    public class CourseRetrieveModel : PageModel
    {
        [BindProperty]
        public List<Course> allCourses { get; set; }

        private readonly ILogger<CourseRetrieveModel> _logger;
        private CourseService _svc;
        public CourseRetrieveModel(ILogger<CourseRetrieveModel> logger, CourseService service)
        {
            _logger = logger;
            _svc = service;
        }
        public void OnGet()
        {
            allCourses = _svc.GetAllCourses();
        }
    }
}
