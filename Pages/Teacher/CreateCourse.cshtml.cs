using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
        private readonly CourseService _svc;
        public CreateCourseModel(CourseService service)
        {
            _svc = service;
        }
        //Check session if valid (teacher access only)
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("userType") != "True")
            {
                return RedirectToPage("../Index");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                //get Session of teacher id
                MyCourses.userID = (int)HttpContext.Session.GetInt32("ID");
                var url = MyCourses.courseVideo;
                var uri = new Uri(url);
                var query = HttpUtility.ParseQueryString(uri.Query);
                if (query.AllKeys.Contains("v"))
                {
                    MyCourses.courseVideo = "https://youtube.com/embed/" + query["v"];
                }
                else
                {
                    MyCourses.courseVideo = "https://youtube.com/embed/" + uri.Segments.Last();
                }

                if (_svc.AddCourse(MyCourses))
                {
                    return RedirectToPage("./CourseList");
                }
                    
            }
            return Page();
        }
    }
}
