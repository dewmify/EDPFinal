using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EDPFinal.Pages.TeacherGuides
{
    public class GuideDetailsModel : PageModel
    {
        [BindProperty]
        public Guides MyGuide { get; set; }
        private readonly ILogger<GuideDetailsModel> _logger;
        private GuideService _svc;
        public GuideDetailsModel(ILogger<GuideDetailsModel> logger, GuideService service)
        {
            _logger = logger;
            _svc = service;

        }
        public void OnGet(string id)
        {
            if (id != null)
            {
                MyGuide = _svc.GetGuideById(id);
            }
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("Index");
        }
    }
}
