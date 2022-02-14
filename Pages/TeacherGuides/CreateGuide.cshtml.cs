using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using EDPFinal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDPFinal.Pages.TeacherGuides
{
    public class CreateGuideModel : PageModel
    {
        private readonly Services.GuideService _svc;
        public CreateGuideModel(Services.GuideService service)
        {
            _svc = service;
        }
        [BindProperty]
        public Guides MyGuide { get; set; }
        public string MyMessage { get; set; }
        public IActionResult OnGet()
        {
            //Checks session for admin type 
            if (HttpContext.Session.GetString("userType") != "admin")
            {
                return RedirectToPage("../Index");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var url = MyGuide.guideVideo;
                var uri = new Uri(url);
                var query = HttpUtility.ParseQueryString(uri.Query);
                if (query.AllKeys.Contains("v"))
                {
                    MyGuide.guideVideo = "https://youtube.com/embed/" + query["v"];
                }
                else
                {
                    MyGuide.guideVideo = "https://youtube.com/embed/" + uri.Segments.Last();
                }
                if (_svc.AddGuide(MyGuide))
                {
                     HttpContext.Session.SetString("SSEmail", MyGuide.guideTitle);
                     return RedirectToPage("GuideConfirm");
                }
                else
                {
                    MyMessage = "Guide title already exists!";
                    return Page();
                }
            }
            return Page();
        }
    }
}
