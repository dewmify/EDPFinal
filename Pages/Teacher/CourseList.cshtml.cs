using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EDPFinal.Pages.Teacher
{
    public class CourseListModel : PageModel
    {
        [BindProperty]
        public List<Course> AllCourses { get; set; }
        private readonly ILogger<CourseListModel> _logger;
        private CourseService _svc;
        public CourseListModel(ILogger<CourseListModel> logger, CourseService service)
        {
            _logger = logger;
            _svc = service;
        }
        public void OnGet()
        {
            AllCourses = _svc.GetAllCourses();
        }
    }
}
