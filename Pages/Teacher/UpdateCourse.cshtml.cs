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

namespace EDPFinal.Pages.Teacher
{
    public class UpdateCourseModel : PageModel
    {
        [BindProperty]
        public Course MyCourses { get; set; }
        public byte[] courseImage { get; set; }
        private readonly CourseService _svc;
        public UpdateCourseModel(CourseService service)
        {
            _svc = service;
        }

        public IActionResult OnGet(int id)
        {
            if (HttpContext.Session.GetString("userType") != "True")
            {
                return RedirectToPage("../Index");
            }
            if (id == null)
            {
                return NotFound();
            }
            if (MyCourses.courseImg != null)
            {
                string imageBase64Data = Convert.ToBase64String(MyCourses.courseImg);
                string imageDataURL = string.Format("data:image/jpg;base64,{0}",
                       imageBase64Data);

                ViewData["ImageDataUrl"] = imageDataURL;
            }
            MyCourses = _svc.GetCourse(id);
            if (MyCourses == null)
            {
                return NotFound();
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
            if (!ModelState.IsValid)
            {
                return Page();
            }
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
            if (_svc.UpdateCourse(MyCourses))
            {
                return RedirectToPage("./CourseList");
            }
            else
                return BadRequest();
        }
    }
}
