using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DMS_API.Data;
using DMS_API.Models.Domain;
using Microsoft.AspNetCore.Identity;

namespace DMS_API.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Add DbSet for other entities in your application
        // public DbSet<Dorm> Dorms { get; set; }
        // public DbSet<House> Houses { get; set; }
        // public DbSet<Floor> Floors { get; set; }
        // public DbSet<Room> Rooms { get; set; }
        // public DbSet<Service> Services { get; set; }
        // public DbSet<Payment> Payments { get; set; }
        public DbSet<Balance> Balances {get; set;}

        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly()
            );

            base.OnModelCreating(modelBuilder);

            SeedData.Seed(modelBuilder);

            // Configure relationships

            //modelBuilder.Entity<Dorm>()
            //    .HasMany(d => d.Floors)
            //    .WithOne(f => f.Dorm)
            //    .HasForeignKey(f => f.DormId);

            //modelBuilder.Entity<Floor>()
            //    .HasMany(f => f.Houses)
            //    .WithOne(h => h.Floor)
            //    .HasForeignKey(h => h.FloorId);

            //modelBuilder.Entity<House>()
            //    .HasMany(h => h.Rooms)
            //    .WithOne(r => r.House)
            //    .HasForeignKey(r => r.HouseId);
        }


    }
}
