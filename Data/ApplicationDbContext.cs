using Microsoft.EntityFrameworkCore;
using CarManufacturersMVC.Models;

namespace CarManufacturersMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public required DbSet<Manufacturer> Manufacturers { get; set; }
        public required DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>()
                .HasIndex(c => c.ManufacturerId);

            modelBuilder.Entity<Manufacturer>()
                .HasIndex(m => m.Name)
                .IsUnique();

            modelBuilder.Entity<Car>()
                .HasIndex(c => new { c.Model });

            modelBuilder.Entity<Car>()
                .HasIndex(c => c.Name);

            modelBuilder.Entity<Car>()
                .HasIndex(c => c.Class);
        }
    }
} 