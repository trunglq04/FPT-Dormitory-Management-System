using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DMS_API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DMS_API.DataAccess
{
    public class ApplicationDbContext : 
        IdentityDbContext<AppUser>, IEntityTypeConfiguration<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        // Add DbSet for other entities in your application
        public DbSet<Dorm> Dorms { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly()
            );

            base.OnModelCreating(modelBuilder);

            // Seeding data
            modelBuilder.Entity<Dorm>().HasData(
                new Dorm { Id = Guid.Parse("beb78b77-f52c-4193-a53a-3b3aa7a14fd9"), Name = "Dorm A" },
                new Dorm { Id = Guid.Parse("d636bf9d-5979-4b6b-8803-3709d18de12c"), Name = "Dorm B" }
            );

            // Configure relationships
            modelBuilder.Entity<Dorm>()
                .HasMany(d => d.Floors)
                .WithOne(f => f.Dorm)
                .HasForeignKey(f => f.DormId);

            modelBuilder.Entity<Floor>()
                .HasMany(f => f.Houses)
                .WithOne(h => h.Floor)
                .HasForeignKey(h => h.FloorId);

            modelBuilder.Entity<House>()
                .HasMany(h => h.Rooms)
                .WithOne(r => r.House)
                .HasForeignKey(r => r.HouseId);
        }


    }
}
