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

namespace EDPFinal.Pages.User
{
    public class LoginJordanModel : PageModel
    {
        private readonly ILogger<LoginJordanModel> _logger;
        private UserService _svc;

        [BindProperty]
        public UserModel myUser { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string errorMessage { get; set; }
        public LoginJordanModel(ILogger<LoginJordanModel> logger, UserService service)
        {
            _logger = logger;
            _svc = service;
        }
        public string errormessage { get; set; }

        public IActionResult OnPost()
        {

            myUser = _svc.GetUserByEmail(Email);
            if (Email.Equals(myUser.userEmail) && myUser.comparePassword(Password))
            {
                HttpContext.Session.SetInt32("ID", myUser.userID);
                HttpContext.Session.SetString("userType", myUser.userType.ToString());
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
            HttpContext.Session.Clear();
            return Page();
        }
        public void OnGet()
        {
        }
    }
}
