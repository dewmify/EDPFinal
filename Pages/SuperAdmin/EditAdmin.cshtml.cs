using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDPFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EDPFinal.Pages.SuperAdmin
{
    public class EditAdminModel : PageModel
    {
        private readonly ILogger<EditAdminModel> _logger;
        private readonly Services.AdminService _svc;

        public EditAdminModel(ILogger<EditAdminModel> logger, Services.AdminService service)
        {
            _logger = logger;
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

                return RedirectToPage("AdminList");
            }
            else
                return BadRequest();
        }
    }
}
