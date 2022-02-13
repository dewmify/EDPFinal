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
using Microsoft.Extensions.Logging;

namespace EDPFinal.Pages.Admin
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        private AdminService _svc;

        [BindProperty]
        public AdminModel MyAdmin { get; set; }

        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string errorMessage { get; set; }
        public LoginModel(ILogger<LoginModel> logger, AdminService service)
        {
            _logger = logger;
            _svc = service;
        }


        public string errormessage { get; set; }
        public IActionResult OnPost()
        {

            MyAdmin = _svc.GetAdminByEmail(Email);
            if(Email.Equals(MyAdmin.adminEmail) && MyAdmin.comparePassword(Password))
            {
                HttpContext.Session.SetString("userType", "admin");
                HttpContext.Session.SetString("Email", MyAdmin.adminEmail.ToString());
                HttpContext.Session.SetInt32("ID", MyAdmin.adminID);
                return RedirectToPage("../Index");
            }
            else
            {
                errorMessage = "Incorrect login details";
                return Page();
            }
        }
        public IActionResult OnGetLogOut()
        {
            HttpContext.Session.Remove("Email");
            return Page();
        }
        public void OnGet()
        {
        }
    }
}
