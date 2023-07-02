using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Project.Model
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
