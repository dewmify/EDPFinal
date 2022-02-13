using EDPFinal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDPFinal.Services
{
    public class BookingService
    {
        private BookingDBContext _context;
        public BookingService(BookingDBContext context)
        {
            _context = context;
        }

        public List<Booking> GetAllBookings()
        {
            List<Booking> AllBookings = new List<Booking>();
            AllBookings = _context.Booking.ToList();
            return AllBookings;
        }

        public bool AddBooking(Booking newbooking)
        {
            if (BookingExists(newbooking.BookingID))
            {
                return false;
            }

            _context.Add(newbooking);
            _context.SaveChanges();
            return true;
        }

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.BookingID == id);
        }

        public Booking GetBookingById(int id)
        {
            var cor = _context.Booking.SingleOrDefault(o => o.BookingID == id);
            return cor;
        }

        public bool UpdateBooking(Booking thebooking)
        {
            bool updated = true;
            _context.Attach(thebooking).State = EntityState.Modified;
            _context.Update(thebooking);
            try
            {
                _context.SaveChanges();
                updated = true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(thebooking.BookingID))
                {
                    updated = false;
                }
                else
                {
                    throw;
                }
            }
            return updated;
        }

        public bool DeleteBooking(Booking thebooking)
        {
            bool deleted = true;

            try
            {
                _context.Remove(thebooking);
                _context.SaveChanges();
                deleted = true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(thebooking.BookingID))
                {
                    deleted = false;
                }
                else
                {
                    throw;
                }
            }
            return deleted;
        }
    }
}
