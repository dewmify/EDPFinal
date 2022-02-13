using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDPFinal.Models;
using EDPFinal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EDPFinal.Pages.CourseBookings
{
    public class BookingsListModel : PageModel
    {
        [BindProperty]
        public List<Booking> AllBookings { get; set; }
        private readonly ILogger<BookingsListModel> _logger;
        private BookingService _svc;

        public BookingsListModel(ILogger<BookingsListModel> logger, BookingService service)
        {
            _logger = logger;
            _svc = service;
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("ID") == null)
            {
                return RedirectToPage("../Index");
            }
            AllBookings = _svc.GetAllBookings();
            return Page();
        }
    }
}
