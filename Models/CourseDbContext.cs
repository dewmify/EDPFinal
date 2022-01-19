using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EDPFinal.Models
{
    public class CourseDbContext: DbContext
    {
        private readonly IConfiguration _config;
        public CourseDbContext(IConfiguration configuration)
        {
            _config = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Get connection string from value of var name in "appsettings"
            string connectionString = _config.GetConnectionString("MyConn");
            optionsBuilder.UseSqlServer(connectionString);
        }
        //Map entity to tablename in database
        public DbSet<Course> Courses { get; set; }
    }
}
