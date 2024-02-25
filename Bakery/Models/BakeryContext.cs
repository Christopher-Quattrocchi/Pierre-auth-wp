using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bakery.Models
{
    public class BakeryContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Flavor> Flavors { get; set; }
        public DbSet<Treat> Treats { get; set; }
        public DbSet<FlavorTreat> FlavorTreats { get; set; }

        public BakeryContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Flavors
            modelBuilder.Entity<Flavor>().HasData(
                new Flavor { FlavorId = 1, Name = "Savory" },
                new Flavor { FlavorId = 2, Name = "Sweet" }
            );

            // Seed Treats
            modelBuilder.Entity<Treat>().HasData(
                new Treat { TreatId = 1, Name = "Croissant" },
                new Treat { TreatId = 2, Name = "Chocolate Croissant" },
                new Treat { TreatId = 3, Name = "Sourdough Bread" }
            );

            // Seed FlavorTreat associations
            modelBuilder.Entity<FlavorTreat>().HasData(
                new FlavorTreat { FlavorTreatId = 1, FlavorId = 2, TreatId = 1 }, 
                new FlavorTreat { FlavorTreatId = 2, FlavorId = 2, TreatId = 2 }, 
                new FlavorTreat { FlavorTreatId = 3, FlavorId = 1, TreatId = 3 } 
            );
        }
    }
}