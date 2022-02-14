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
    public class UnapprovedTeachersModel : PageModel
    {
        [BindProperty]
        public List<UserModel> AllUsers { get; set; }

        public UserModel MyUser { get; set; }
        private readonly ILogger<UnapprovedTeachersModel> _logger;
        private UserService _svc;

        public UnapprovedTeachersModel(ILogger<UnapprovedTeachersModel> logger, UserService service)
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

        public IActionResult OnPost(int id)
        {
            var user = _svc.GetUserById(id);
            if(user == null)
            {
                return NotFound();
            }
            if (user.ResumePDF == null)
            {
                return Page();
            }
            else
            {
                byte[] byteArr = user.ResumePDF;
                string mimeType = "application/pdf";
                return new FileContentResult(byteArr, mimeType)
                {
                    FileDownloadName = $"Resume {MyUser.userName}.pdf"
                };
            }
            
            return Page();
        }
    }
}
