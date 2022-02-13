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
        public IFormFile file { get; set; }
        
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
            Console.WriteLine("Starting OnPost");
            if(file != null)
            {
                Console.WriteLine("made it to line 39");
                if(file.Length > 0 && file.Length < 300000)
                {
                    Console.WriteLine("Made it to line 42");
                    using (var target = new MemoryStream())
                    {
                        file.CopyTo(target);
                        myUser.ResumePDF = target.ToArray();
                    }
                    myUser.userID = (int)HttpContext.Session.GetInt32("ID");
                    myUser.userPassword = myUser.userPassword;
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
