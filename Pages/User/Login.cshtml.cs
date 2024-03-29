using EDPFinal.Models;
using EDPFinal.Services;
using EDPFinal.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace EDPFinal.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        private UserService _svc;

        [BindProperty]
        public UserModel myUser { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string errorMessage { get; set; }
        public LoginModel(ILogger<LoginModel> logger, UserService service)
        {
            _logger = logger;
            _svc = service;
        }

        public string errormessage { get; set; }

        private class MyObject
        {
            public string success { get; set; }
            public List<string> ErrorMessage { get; set; }
        }

        public bool ValidateCaptcha()
        {
            bool result = true;

            //When user submits the recaptcha form, the user gets a response POST parameter. 
            //captchaResponse consist of the user click pattern. Behaviour analytics! AI :) 
            string captchaResponse = Request.Form["g-recaptcha-response"];

            //To send a GET request to Google along with the response and Secret key.
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create
           ("https://www.google.com/recaptcha/api/siteverify?secret=6Levux0eAAAAAPNlO_BcU5LTpIqk_JOtZYZuvT8Y&response=" + captchaResponse);


            try
            {

                //Codes to receive the Response in JSON format from Google Server
                using (WebResponse wResponse = req.GetResponse())
                {
                    using (StreamReader readStream = new StreamReader(wResponse.GetResponseStream()))
                    {
                        //The response in JSON format
                        string jsonResponse = readStream.ReadToEnd();

                        //To show the JSON response string for learning purpose
                        //lbl_gScore.Text = jsonResponse.ToString();


                     

                        //Create jsonObject to handle the response e.g success or Error
                        //Deserialize Json
                        MyObject jsonObject = JsonConvert.DeserializeObject<MyObject>(jsonResponse);

                        //Convert the string "False" to bool false or "True" to bool true
                        result = Convert.ToBoolean(jsonObject.success);//

                    }
                }

                return result;
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }

        public IActionResult OnPost()
        {



            if (ValidateCaptcha())
            {
                myUser = _svc.GetUserByEmail(Email);
                if (Email.Equals(myUser.userEmail) && myUser.comparePassword(Password))
                {
                    HttpContext.Session.SetInt32("ID", myUser.userID);
                    HttpContext.Session.SetString("userType", myUser.userType.ToString());
                    return RedirectToPage("../Index");
                }
                else
                {
                    errorMessage = "Incorrect login details";
                    return Page();
                }
            }
            else
            {
                return Page();
             }
           
        }
        public IActionResult OnGetLogOut()
        {
            HttpContext.Session.Remove("ID");
            HttpContext.Session.Clear();
            return Page();
        }
        public void OnGet()
        {
        }
    }
}
