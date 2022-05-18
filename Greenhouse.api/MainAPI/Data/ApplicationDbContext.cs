using MainAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MainAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        { }


        public DbSet<User>? Users { get; set; }


        public DbSet<API> APIs { get; set; }
    }

}
