using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDPFinal.Pages.TeacherGuides
{
    public class GuideConfirmModel : PageModel
    {
        [BindProperty]
        public String PageMessage { get; set; }
        public IActionResult OnGet()
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("SSEmail")))
            {
                PageMessage = HttpContext.Session.GetString("SSEmail") + " guide created";
                HttpContext.Session.Clear();
                return Page();
            }
            return Redirect("CreateGuide");
        }
    }
}
