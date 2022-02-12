using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDPFinal.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Course> AllCourses { get; set; }
        private readonly ILogger<IndexModel> _logger;
        private CourseService _svc;

        public IndexModel(ILogger<IndexModel> logger, CourseService service)
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
