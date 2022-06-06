using MainAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MainAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        { }

        public DbSet<API>? APIs { get; set; }

        public DbSet<APIUser>? APIUsers { get; set; }

        public DbSet<Role>? Roles { get; set; }

        public DbSet<Sensor>? Sensors { get; set; }

        public DbSet<SensorType>? SensorTypes { get; set; }

        public DbSet<Asset>? Assets { get; set; }

        public DbSet<AssetTypeId>? AssetTypes { get; set; }

        public DbSet<AssetSensor> AssetSensors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AssetSensor>()
            .HasKey(c => new { c.AssetId, c.SensorId });
            modelBuilder.Entity<AssetSensor>()
            .HasOne(c => c.Asset).WithMany(c => c.Sensors).HasForeignKey(c => c.AssetId);
            modelBuilder.Entity<AssetSensor>()
            .HasOne(c => c.Sensor).WithMany(c => c.Assets).HasForeignKey(c => c.SensorId);
        }
    }
}
