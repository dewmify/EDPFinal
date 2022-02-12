using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDPFinal.Pages.TeacherGuides
{
    public class EditGuideModel : PageModel
    {
        private readonly GuideService _svc;
        public EditGuideModel(GuideService service)
        {
            _svc = service;
        }
        [BindProperty]
        public Guides MyGuide { get; set; }

        public IActionResult OnGet(int id)
        {
            if (HttpContext.Session.GetString("userType") != "admin")
            {
                return RedirectToPage("../Index");
            }
            if (id == 0)
            {
                return NotFound();
            }
            MyGuide = _svc.GetGuideById(id);
            if (MyGuide == null)
            {
                return NotFound();
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (_svc.UpdateGuide(MyGuide) == true)
            {
                return RedirectToPage("RetrieveGuide");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
