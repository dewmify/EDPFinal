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
        public User user { get; set; }
        public UserDetailModel(UserService userService)
        {
            _context = userService;
        }
        public void OnGet()
        {
            if (HttpContext.Session.GetString("ID")!=null)

            {
                 user = _context.GetUserById(Convert.ToInt32(HttpContext.Session.GetString("ID")));


            }
           
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("");
        }
    }
}
