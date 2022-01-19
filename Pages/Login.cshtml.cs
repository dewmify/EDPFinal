using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace EDPFinal.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty] public string Email { get; set; }
        [BindProperty] public string Password { get; set; }
        [BindProperty] public string Name { get; set; }
        [BindProperty] public string Phonenum { get; set; }
        public void OnGet()
        {
        }
    }
}
