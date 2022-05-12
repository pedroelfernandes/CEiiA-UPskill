using Microsoft.EntityFrameworkCore;

namespace MainAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        { }

        //public DbSet<Reading>? Readings { get; set; }
    }

}
