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
        [BindProperty]
        public Admin MyAdmin { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("SSEmail", MyAdmin.Email);
                return RedirectToPage("AdminList");
            }
            return Page();
        }
    }
}
