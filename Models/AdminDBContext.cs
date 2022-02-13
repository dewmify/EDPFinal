using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDPFinal.Models
{
    public class AdminDBContext : DbContext
    {
        private readonly IConfiguration _config;

        public AdminDBContext(IConfiguration configuration)
        {
            _config = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            string connectionString = _config.GetConnectionString("MyConn");
            optionBuilder.UseSqlServer(connectionString);
        }

        public DbSet<AdminModel> Admin { get; set; }
    }
}
