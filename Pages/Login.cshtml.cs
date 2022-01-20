using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace EDPFinal.Pages
{
    public class LoginModel : PageModel
    {
        private readonly UserService _context;

        public LoginModel(UserService userService)
        {
            _context = userService;
        }

        [BindProperty] public string Email { get; set; }
        [BindProperty] public string Password { get; set; }
        [BindProperty] public string Name { get; set; }
        [BindProperty] public string Phonenum { get; set; }

        public string errormessage { get; set; }
        public IActionResult OnPost()
        {

            User user = _context.GetUserByEmail(Email);
            if (user == null || user.userPassword != Password)
            {
               errormessage = "Email or Password is incorrect!";
                return Page();
            }

            HttpContext.Session.SetString("ID", user.userID.ToString());
            return RedirectToPage("/Homepage");
        }

        public void OnGet()
        {
        }
    }
}
