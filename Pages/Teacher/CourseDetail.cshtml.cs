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
    public class CourseDetailModel : PageModel
    {
        [BindProperty]
        public Course MyCourse { get; set; }
        private readonly ILogger<CourseDetailModel> _logger;
        private CourseService _svc;
        public CourseDetailModel(ILogger<CourseDetailModel> logger, CourseService service)
        {
            _logger = logger;
            _svc = service;

        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("userType") != "True")
            {
                return RedirectToPage("../Index");
            }
            return Page();
        }
        public void OnGet(int id)
        {
            if (id != 0)
            {
                MyCourse = _svc.GetCourse(id);
            }
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("");
        }
    }
}
