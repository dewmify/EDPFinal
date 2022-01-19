using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDPFinal.Pages.SuperAdmin
{
    public class AdminDetailModel : PageModel
    {
        [BindProperty]
        public Admin MyAdmin { get; set; }
        private AdminService _svc;
        public void OnGet(string id)
        {
            if(id != null)
            {
                MyAdmin = _svc.GetAdminById(id);
            }
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("Index");
        }
    }
}
