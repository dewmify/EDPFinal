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

namespace EDPFinal.Pages.AdminPages
{
    public class LoginModel : PageModel
    {
        private readonly AdminService _context;

        public LoginModel(AdminService userService)
        {
            _context = userService;
        }

        [BindProperty] 
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }
        
        [BindProperty] 
        public string Name { get; set; }
        
        [BindProperty] 
        public string Phonenum { get; set; }

        public string errormessage { get; set; }
        public IActionResult OnPost()
        {

            Admin admin = _context.GetAdminByEmail(Email);
            if (admin == null || admin.Password != Md5.GetMD5(Password))
            {
                errormessage = "Incorrect login details";
                return Page();
            }
            else
            {
                HttpContext.Session.SetString("role", "admin");
                HttpContext.Session.SetString("Email", admin.Email.ToString());
                return RedirectToPage("/Homepage");
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
