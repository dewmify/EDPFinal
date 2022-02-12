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
    public class LiveTestModel : PageModel
    {
        [BindProperty]
        public Course MyCourse { get; set; }
        private readonly ILogger<LiveTestModel> _logger;
        private CourseService _svc;
        public LiveTestModel(ILogger<LiveTestModel> logger, CourseService service)
        {
            _logger = logger;
            _svc = service;

        }
        public void OnGet(int id)
        {
            if (id != null)
            {
                MyCourse = _svc.GetCourse(id);
            }
        }
    }
}
