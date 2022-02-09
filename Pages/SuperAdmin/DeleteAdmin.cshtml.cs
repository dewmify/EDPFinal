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
    public class DeleteAdminModel : PageModel
    {
        private readonly ILogger<DeleteAdminModel> _logger;
        private readonly AdminService _svc;
        public DeleteAdminModel(ILogger<DeleteAdminModel> logger, AdminService service)
        {
            _logger = logger;
            _svc = service;
        }
        [BindProperty]

        public Admin MyAdmin { get; set; }
        public IActionResult OnGet(string id)
        {
            if (id != null)
            {
                MyAdmin = _svc.GetAdminById(id);
            }
            else
                return RedirectToPage("./AdminList");
            if (_svc.DeleteAdmin(MyAdmin))
            {
                return RedirectToPage("./AdminList");
            }
            else
            {
                return Page();
            }
        }
        
    }
}
