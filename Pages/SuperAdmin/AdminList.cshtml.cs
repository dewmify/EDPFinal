using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EDPFinal.Pages.SuperAdmin
{
    public class AdminListModel : PageModel
    {
        [BindProperty]
        public List<AdminModel> alladmins { get; set; }

        private readonly ILogger<AdminListModel> _logger;
        private AdminService _svc;

        public AdminListModel(ILogger<AdminListModel> logger, AdminService service)
        {
            _logger = logger;
            _svc = service;
        }
        public void OnGet()
        {
            alladmins = _svc.GetAllAdmins();
        }
    }
}
