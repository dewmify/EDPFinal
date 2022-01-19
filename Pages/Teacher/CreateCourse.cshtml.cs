using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDPFinal.Pages.Teacher
{
    public class CreateCourseModel : PageModel
    {
        [BindProperty]
        public Course MyCourses { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                //Use session if req
                //HttpContext.Session.SetString("SSTitle", MyCourses.courseTitle);
                //Redirect to Teachers Details Page
                return RedirectToPage("");
            }
            return Page();
        }
    }
}
