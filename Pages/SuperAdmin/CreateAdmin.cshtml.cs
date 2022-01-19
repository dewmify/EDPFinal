using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDPFinal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDPFinal.Pages.SuperAdmin
{
    public class CreateAdminModel : PageModel
    {
        private readonly Services.AdminService _svc;
        public CreateAdminModel(Services.AdminService service)
        {
            _svc = service;
        }
        [BindProperty]
        public Admin MyAdmin { get; set; }
        public string MyMessage { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if(_svc.AddAdmin(MyAdmin))
                {
                     HttpContext.Session.SetString("SSEmail", MyAdmin.Email);
                     return RedirectToPage("AdminConfirm");
                }
                else
                {
                    MyMessage = "Admin ID Already Exists!";
                    return Page();
                }
            }
            return Page();
        }
    }
}
