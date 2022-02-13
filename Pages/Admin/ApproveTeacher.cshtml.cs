using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EDPFinal.Pages.Admin
{
    public class ApproveTeacherModel : PageModel
    {
        private readonly ILogger<ApproveTeacherModel> _logger;
        private readonly UserService _svc;
        public ApproveTeacherModel(ILogger<ApproveTeacherModel> logger, UserService service)
        {
            _logger = logger;
            _svc = service;
        }
        [BindProperty]

        public UserModel MyTeacher { get; set; }
        public IActionResult OnGet(int id)
        {
            if (id != null)
            {
                MyTeacher = _svc.GetUserById(id);
            }
            else
                return RedirectToPage("./UnapprovedTeachers");

            MyTeacher.userType = true;

            if (_svc.UpdateUser(MyTeacher))
            {
                return RedirectToPage("./UnapprovedTeachers");
            }
            else
            {
                return Page();
            }
        }
    }
}
