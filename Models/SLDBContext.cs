using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;


namespace EDPFinal.Models
{
    public class SLDBContext
    {
        private readonly IConfiguration _config;
        public SLDBContext(IConfiguration configuration)
        {
            _config = configuration;
        }

        protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //protected override void
        {
            string connectionString = _config.GetConnectionString("Myconnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Course> courses { get; set; }
    }
}
