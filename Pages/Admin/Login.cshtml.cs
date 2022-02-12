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
        public AdminModel Admin { get; set; }
        public LoginModel(ILogger<LoginModel> logger, AdminService service)
        {
            _logger = logger;
            _svc = service;
        }


        public string errormessage { get; set; }
        public IActionResult OnPost()
        {

            Admin = _svc.GetAdminByEmail(Admin.Email);
            if (Admin == null || Admin.Password != Md5.GetMD5(Admin.Password))
            {
                errormessage = "Incorrect login details";
                return Page();
            }
            else
            {
                HttpContext.Session.SetString("userType", "admin");
                HttpContext.Session.SetString("Email", Admin.Email.ToString());
                return RedirectToPage("../Index");
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
