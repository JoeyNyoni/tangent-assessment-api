using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}
