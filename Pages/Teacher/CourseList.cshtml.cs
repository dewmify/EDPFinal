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
    public class CourseListModel : PageModel
    {
        [BindProperty]
        public List<Course> AllCourses { get; set; }
        [BindProperty]
        public List<Booking> AllBooking { get; set; }
        private readonly ILogger<CourseListModel> _logger;
        private CourseService _svc;
        private BookingService _bsvc;
        public CourseListModel(ILogger<CourseListModel> logger, CourseService service, BookingService bservice)
        {
            _logger = logger;
            _svc = service;
            _bsvc = bservice;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("userType") != "True")
            {
                return RedirectToPage("../Index");
            }
            AllCourses = _svc.GetAllCourses();
            AllBooking = _bsvc.GetAllBookings();
            return Page();
        }
    }
}
