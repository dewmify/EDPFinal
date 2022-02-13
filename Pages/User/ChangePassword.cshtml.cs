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

        public IActionResult OnPost()
        {

            //GET user
            var id = Convert.ToInt32(HttpContext.Session.GetInt32("ID"));
            var user = _context.GetUserById(id);
            if (user != null)
            {

                //Check old password
                if (user.userPassword == Md5.GetMD5(OldPassWord))
                {
                    user.userPassword = Md5.GetMD5(Password);
                    _context.UpdateUser(user);
                    HttpContext.Session.Remove("ID");
                    HttpContext.Session.Clear();

                    return RedirectToPage("Login");
                }

            }
            return Page();


        }
        public void OnGet()
        {
        }
    }
}
