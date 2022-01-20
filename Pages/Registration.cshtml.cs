using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace EDPFinal.Pages
{
    public class RegistrationModel : PageModel
    {
        private readonly UserService _context;

        public RegistrationModel(UserService userService)
        {
            _context = userService;
        }
        [BindProperty] public string Email { get; set; }
        [BindProperty] public string Password { get;set;}
        [BindProperty] public string CfmPassword { get; set; }
        [BindProperty] public string Name { get; set; }
        [BindProperty] public string Phonenum { get; set; }
        public IActionResult OnPost()
        {
            var newUser = new User()
            {
                userEmail = Email,
                userPassword = Password,
                userName = Name,
                userPhoneNo = Phonenum
            };
            _context.AddUser(newUser);
            return RedirectToPage("Login");
        }
        public void OnGet()
        {
        }
    }
}
