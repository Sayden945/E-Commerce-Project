using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Project.Models
{
    public class dbContext : DbContext
    {
        public DbSet<user> customers { get; set; }

        public dbContext(DbContextOptions options) : base(options) 
        { 
        }
    }
}
