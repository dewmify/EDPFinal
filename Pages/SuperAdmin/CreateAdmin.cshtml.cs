using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [EmailAddress, RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Invalid email")]
        public string Email { get; set; }

        //Regex for Img "^([A-Za-z0-9_\\.\\-])+(.jpeg|.jpg|.png|.gif)$"
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
                    return RedirectToPage("/SuperAdmin/AdminList");
                }
            }
            return Page();
        }
    }
}
