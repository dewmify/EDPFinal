using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EDPFinal.Pages.TeacherGuides
{
    public class DeleteGuideModel : PageModel
    {
        private readonly ILogger<DeleteGuideModel> _logger;

        private readonly GuideService _svc;

        public DeleteGuideModel(ILogger<DeleteGuideModel> logger, GuideService service)
        {
            _logger = logger;
            _svc = service;
        }

        [BindProperty]
        public Guides MyGuide { get; set; }

        public IActionResult OnGet(int id)
        {
            if (id != 0)
            {
                MyGuide = _svc.GetGuideById(id);
            }
            else
                return RedirectToPage("../Index");

            if(_svc.DeleteGuide(MyGuide))
            {
                return RedirectToPage("RetrieveGuide");
            }
            else
            {
                return Page();
            }

           
        }
    }
}
