using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDPFinal.Models;
using EDPFinal.Services;
using EDPFinal.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDPFinal.Pages.SuperAdmin
{
    public class CreateAdminModel : PageModel
    {
        [BindProperty]
        public AdminModel MyAdmin { get; set; }
        private readonly AdminService _svc;

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string Email { get; set; }
        public CreateAdminModel(AdminService service)
        {
            _svc = service;
        }
        
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                MyAdmin.setPassword(Password);
                MyAdmin.adminEmail = Email;
                if (_svc.AddAdmin(MyAdmin))
                {
                    return RedirectToPage("./AdminConfirm");
                }
            }
            return Page();
        }
    }
}
