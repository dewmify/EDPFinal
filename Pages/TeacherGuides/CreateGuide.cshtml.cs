using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                if(_svc.AddGuide(MyGuide))
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
