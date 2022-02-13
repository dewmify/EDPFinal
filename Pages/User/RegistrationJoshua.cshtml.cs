using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDPFinal.Pages.User
{
    public class RegistrationJoshuaModel : PageModel
    {
        private readonly UserService _svc;

        [BindProperty]
        [EmailAddress, RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Invalid email")]
        public string Email { get; set; }
        [BindProperty] public string Password { get; set; }
        [BindProperty] public string CfmPassword { get; set; }
        [BindProperty] public string Name { get; set; }

        [BindProperty]
        public UserModel myUser { get; set; }

        [BindProperty]
        [StringLength(maximumLength: 8, MinimumLength = 8)]
        public string Phonenum { get; set; }
        public byte[] Picture { get; set; }
        public RegistrationJoshuaModel(UserService service)
        {
            _svc = service;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            foreach (var file in Request.Form.Files)
            {
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                Picture = ms.ToArray();

                ms.Close();
                ms.Dispose();
            }

            if (ModelState.IsValid)
            {
                myUser.setPassword(Password);
                myUser.userEmail = Email;
                myUser.profilePictureData = Picture;
                myUser.userName = Name;
                myUser.userPhoneNo = Phonenum;

                if (_svc.AddUser(myUser))
                {
                    return RedirectToPage("/User/Login");
                }
            }
            return Page();
        }
    }
}
