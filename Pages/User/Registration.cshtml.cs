using EDPFinal.Models;
using EDPFinal.Services;
using EDPFinal.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace EDPFinal.Pages
{
    public class RegistrationModel : PageModel
    {
        private readonly UserService _context;

        public RegistrationModel(UserService userService)
        {
            _context = userService;
        }
        [BindProperty]
        [EmailAddress]
        public string Email { get; set; }
        [BindProperty] public string Password { get;set;}
        [BindProperty] public string CfmPassword { get; set; }
        [BindProperty] public string Name { get; set; }

        [BindProperty]
        [StringLength(maximumLength:8,MinimumLength =8)]
        public string Phonenum { get; set; }

        public byte[] Picture { get; set; }

        public IActionResult OnPost()
        {
            foreach(var file in Request.Form.Files)
            {
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                Picture = ms.ToArray();

                ms.Close();
                ms.Dispose();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }
            var newUser = new UserModel()
            {
                userEmail = Email,
                userPassword =Md5.GetMD5(Password),
                userName = Name,
                userPhoneNo = Phonenum,
                profilePictureData = Picture
            };
            _context.AddUser(newUser);
            return RedirectToPage("Login");
        }
        public void OnGet()
        {
        }
    }
}
