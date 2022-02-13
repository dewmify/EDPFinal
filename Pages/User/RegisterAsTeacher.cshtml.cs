using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.IO;
using System.Threading.Tasks;

namespace EDPFinal.Pages
{
    public class RegisterAsTeacherModel : PageModel
    {
        private readonly UserService _svc;
        public RegisterAsTeacherModel(UserService service)
        {
            _svc = service;
        }

        [BindProperty]
        public IFormFile ResumePDF { get; set; }
        
        [BindProperty]
        public UserModel myUser { get; set; }

        public void OnGet()
        {
            if(HttpContext.Session.GetString("userType") != "True")
            {
                myUser = _svc.GetUserById(Convert.ToInt32(HttpContext.Session.GetInt32("ID")));
            }
        }

        public IActionResult OnPost()
        {
            if(ResumePDF != null)
            {
                Console.WriteLine("made it past line 36");
                if(ResumePDF.Length > 0 && ResumePDF.Length < 300000)
                {
                    Console.WriteLine("made it past line 39");
                     myUser = _svc.GetUserById(myUser.userID);

                    using(var target = new MemoryStream())
                    {
                        ResumePDF.CopyTo(target);
                        myUser.ResumePDF = target.ToArray();
                    }
                    myUser.userID = (int)HttpContext.Session.GetInt32("ID");
                    myUser.registrationStatus = true;
                    if (_svc.UpdateUser(myUser))
                    {
                        return RedirectToPage("/UserDetail");
                    }
                }
            }
            return Page();
        }
    }
}
