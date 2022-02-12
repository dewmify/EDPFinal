using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EDPFinal.Pages.AdminPages
{
    public class ApproveTeacherModel : PageModel
    {
        [BindProperty]
        public List<User> AllUsers { get; set; }
        private readonly ILogger<ApproveTeacherModel> _logger;
        private UserService _svc;

        public ApproveTeacherModel(ILogger<ApproveTeacherModel> logger, UserService service)
        {
            _logger = logger;
            _svc = service;
        }
        public void OnGet()
        {
            AllUsers = _svc.GetAllUsers();
        }
    }
}
