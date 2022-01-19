using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EDPFinal.Models
{
    public class UserDbContext: DbContext
    {
        private readonly IConfiguration _config;
        
        public UserDbContext(IConfiguration configuration)
        {
            _config = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            string connectionString = _config.GetConnectionString("MyConn");
            optionBuilder.UseSqlServer(connectionString);
        }

        public DbSet<User> Users { get; set; }
    }
}
