using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace EDPFinal.Pages
{
    public class RegistrationModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }
        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    string strName = Request.Form["username"];
        //    string email = Request.Form["email"];
        //    string pwd = Request.Form["password"];
        //    string aginpwd = Request.Form["againpwd"];
        //    if (!pwd.Equals(aginpwd))
        //    {
        //        //Response.Write("<script>alert('Password does not match')</script>");
        //        return;
        //    }
        //}
        public void OnGet()
        {
        }
    }
}
