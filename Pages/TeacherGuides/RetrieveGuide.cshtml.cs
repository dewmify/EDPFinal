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
    public class RetrieveGuideModel : PageModel
    {
        [BindProperty]
        public List<Guides> allguides { get; set; }

        private readonly ILogger<RetrieveGuideModel> _logger;
        private GuideService _svc;
        public RetrieveGuideModel(ILogger<RetrieveGuideModel> logger, GuideService service)
        {
            _logger = logger;
            _svc = service;
        }
        public void OnGet()
        {
            allguides = _svc.GetAllGuides();
        }
    }
}
