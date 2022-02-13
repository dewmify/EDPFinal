using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDPFinal.Pages.CourseBookings
{
    public class UpdateBookingModel : PageModel
    {
        [BindProperty]
        public Booking MyBooking { get; set; }
        public Course coursedetails { get; set; }
        private readonly CourseService _corsvc;
        private readonly BookingService _svc;

        public string formatValue;
        public int courseID;
        public UpdateBookingModel(BookingService service, CourseService service1)
        {
            _svc = service;
            _corsvc = service1;
        }

        public IActionResult OnGet(int id)
        {
            
            if (HttpContext.Session.GetString("ID") == null)
            {
                return RedirectToPage("../Index");
            }
            if (id == 0)
            {
                return NotFound();
            }
            MyBooking = _svc.GetBookingById(id);
            if (MyBooking == null)
            {
                return NotFound();
            }
            courseID = MyBooking.CourseID;
            coursedetails = _corsvc.GetCourse(courseID);
            HttpContext.Session.SetInt32("CourseID", coursedetails.courseID);
            if (coursedetails.courseFormat)
            {
                formatValue = "Live";
            }
            else if (coursedetails.courseFormat == false)
            {
                formatValue = "Video";
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                Console.WriteLine(errors);
            }
            MyBooking.CourseID = (int)HttpContext.Session.GetInt32("CourseID");
            MyBooking.StudentID = (int)HttpContext.Session.GetInt32("ID");
            if (_svc.UpdateBooking(MyBooking) == true)
            {
                return RedirectToPage("/CourseBookings/BookingsList");
            }
            else
                return BadRequest();
        }
    }
}
