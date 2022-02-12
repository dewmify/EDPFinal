using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EDPFinal.Pages.SuperAdmin
{
    public class AdminDetailModel : PageModel
    {
        [BindProperty]
        public AdminModel MyAdmin { get; set; }
        private readonly ILogger<AdminDetailModel> _logger;
        private AdminService _svc;
        public AdminDetailModel(ILogger<AdminDetailModel> logger, AdminService service)
        {
            _logger = logger;
            _svc = service;

        }
        public void OnGet(string id)
        {
            if(id != null)
            {
                MyAdmin = _svc.GetAdminById(id);
            }
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("Index");
        }
    }
}
