using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDPFinal.Pages.CourseBookings
{
    public class BookingModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("userType") != "True")
            {
                return RedirectToPage("../Index");
            }
            return Page();
        }
    }
}

//public List<Course> GetAllCourses()
//{
//  List<Course> AllCourses = new List<Course>();
//AllCourses = _context.
//}