using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDPFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDPFinal.Pages.SuperAdmin
{
    public class EditAdminModel : PageModel
    {
        private readonly Services.AdminService _svc;

        public EditAdminModel(Services.AdminService service)
        {
            _svc = service;
        }
        [BindProperty]
        public Admin MyAdmin { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            MyAdmin = _svc.GetAdminById(id);
            if(MyAdmin == null)
            {
                return NotFound();
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if (_svc.UpdateAdmin(MyAdmin) == true)
            {
                return RedirectToPage("./AdminList");
            }
            else
                return BadRequest();
        }
    }
}
