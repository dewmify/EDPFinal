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

namespace EDPFinal.Pages.Admin
{
    public class UserListModel : PageModel
    {
        [BindProperty]
        public List<UserModel> AllUsers { get; set; }
        private readonly ILogger<UserListModel> _logger;
        private UserService _svc;

        public UserListModel(ILogger<UserListModel> logger, UserService service)
        {
            _logger = logger;
            _svc = service;
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("userType") != "admin")
            {
                return RedirectToPage("../Index");
            }
            AllUsers = _svc.GetAllUsers();
            return Page();
        }
    }
}
