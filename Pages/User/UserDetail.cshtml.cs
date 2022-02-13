using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
namespace EDPFinal.Pages
{
    public class UserDetailModel : PageModel
    {
     
        private readonly UserService _context;

        [BindProperty]
        public UserModel user { get; set; }

        public UserDetailModel(UserService userService)
        {
            _context = userService;
        }
        public void OnGet()
        {
            if (HttpContext.Session.GetInt32("ID")!=null)
            {

                user = _context.GetUserById(Convert.ToInt32(HttpContext.Session.GetInt32("ID")));

                string imageBase64Data = Convert.ToBase64String(user.profilePictureData);
                string imageDataURL = string.Format("data:image/jpg;base64,{0}",
                    imageBase64Data);

                ViewData["ImageDataUrl"] = imageDataURL;



            }
           
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("");
        }
        public IActionResult OnPostDelAccount()
        {
            if (HttpContext.Session.GetInt32("ID") != null)

            {
                _context.DestroyUser(Convert.ToInt32(HttpContext.Session.GetInt32("ID")));
                HttpContext.Session.Remove("ID");
                return RedirectToPage("Login");

            }
            return NotFound();
        }
    }
}
