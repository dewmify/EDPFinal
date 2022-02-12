using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EDPFinal.Pages.CourseBookings
{
    public class CreateBookingModel : PageModel
    {
        private readonly ILogger<CreateBookingModel> _logger;
        
        private BookingService _svc;
        private CourseService _coursesvc;


        public CreateBookingModel(ILogger<CreateBookingModel> logger, BookingService service, CourseService service1)
        {
            _logger = logger;
            _svc = service;
            _coursesvc = service1;
        }

        [BindProperty]
        public Booking MyBooking { get; set; }
        [BindProperty]
        public Course coursedetails { get; set; }

        public void OnGet(int Id)
        {
            coursedetails = _coursesvc.GetCourse(Id);

        }

        public IActionResult OnPost()
        {
            coursedetails = _coursesvc.GetCourse(MyBooking.CourseID);
            return Page();
        }
    }
}
