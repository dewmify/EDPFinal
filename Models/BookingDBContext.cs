using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EDPFinal.Models
{
    public class BookingDBContext : DbContext
    {
        private readonly IConfiguration _config;

        public BookingDBContext(IConfiguration configuration)
        {
            _config = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            string connectionString = _config.GetConnectionString("MyConn");
            optionBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Booking> Bookings { get; set; }
    }
}
