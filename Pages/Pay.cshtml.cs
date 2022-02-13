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
    public class PayModel : PageModel
    {
        private readonly UserService _context;

        private readonly CourseService _courseService;

        public PayModel(UserService userService,CourseService courseService)
        {
            _context = userService;
            _courseService = courseService;
        }
       
        public string message { get; set; }
        [BindProperty]
        public Course course { get; set; }
        [BindProperty]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [BindProperty]
        [Required]
      
        public string Name { get; set; }
        [BindProperty]
       
        public string CardNumber { get; set; }
        [BindProperty]
        public DateTime ExpDate { get; set; }
        [BindProperty]
        public string Cvv { get; set; }
        [BindProperty]
        public string PostalCode { get; set; }
        public IActionResult OnPost()
        {


            if (!ModelState.IsValid)
            {
                return Page();
            }
            message = "<script>alert() window.location.href='/CourseBookings/BookingsList'</script>";

            return Page();


        }
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            course = _courseService.GetCourse(id.Value);

            return Page();
        }
    }
}
