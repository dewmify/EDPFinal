using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDPFinal.Pages.Admin
{
    public class CreateCourseModel : PageModel
    {
        [BindProperty]
        public Course MyCourses { get; set; }
        public byte[] courseImage { get; set; }
        private readonly CourseService _svc;
        public CreateCourseModel(CourseService service)
        {
            _svc = service;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("userType") != "admin")
            {
                return RedirectToPage("../Index");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            foreach (var file in Request.Form.Files)
            {
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                courseImage = ms.ToArray();

                ms.Close();
                ms.Dispose();
            }

            if (ModelState.IsValid)
            {
                MyCourses.userID = (int)HttpContext.Session.GetInt32("ID");
                MyCourses.courseImg = courseImage;
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
