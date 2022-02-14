using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using EDPFinal.Tools;
using Microsoft.AspNetCore.Http;

namespace EDPFinal.Pages
{
    public class ChangePasswordModel : PageModel
    {
        private readonly UserService _context;

        public ChangePasswordModel(UserService userService)
        {
            _context = userService;
        }
        [BindProperty]
        [Required]
        public string OldPassWord { get; set; }
        [BindProperty] 
        [Required]
 
        public string Password { get;set;}
        [BindProperty]
        [Compare("Password")]
        [Required]
        public string CfmPassword { get; set; }

        public UserModel myUser { get; set; }

        public IActionResult OnPost()
        {
            if (myUser != null)
            {

                //Check old password
                if (myUser.comparePassword(OldPassWord))
                {
                    myUser.userPassword = myUser.setPassword(Password);
                    _context.UpdateUser(myUser);
                    HttpContext.Session.Remove("ID");
                    HttpContext.Session.Clear();

                    return RedirectToPage("Login");
                }

            }
            return Page();


        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("ID") != null)
            {
                myUser = _context.GetUserById(Convert.ToInt32(HttpContext.Session.GetInt32("ID")));
                return Page();
            }
            return RedirectToPage("../Index");
        }
    }
}
