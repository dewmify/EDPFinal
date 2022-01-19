using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace EDPFinal.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Login { get; set; }
            public void OnGet()
        {
        }
    }
}
