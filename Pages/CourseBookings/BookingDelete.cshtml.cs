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
    public class BookingDeleteModel : PageModel
    {
        private readonly ILogger<BookingDeleteModel> _logger;

        private readonly BookingService _svc;
        private readonly CourseService _corsvc;
        public int courseID;

        public BookingDeleteModel(ILogger<BookingDeleteModel> logger, BookingService service, CourseService service1)
        {
            _logger = logger;
            _svc = service;
            _corsvc = service1;
        }

        [BindProperty]
        public Booking MyBooking { get; set; }
        public Course coursedetails { get; set; }

        public IActionResult OnGet(int id)
        {
            if (id != 0)
            {
                MyBooking = _svc.GetBookingById(id);
            }
            else
                return RedirectToPage("../Index");

            courseID = MyBooking.CourseID;
            coursedetails = _corsvc.GetCourse(courseID);

            if (_svc.DeleteBooking(MyBooking))
            {
                return RedirectToPage("/CourseBookings/BookingsList");
            }
            else
            {
                return Page();
            }


        }
    }
}
