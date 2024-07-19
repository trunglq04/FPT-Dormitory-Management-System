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
        public DbSet<Dorm> Dorms { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }

        // public DbSet<Payment> Payments { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingService> BookingServices { get; set; }

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

            // Configure one-to-one relationship between AppUser and RefreshToken
            modelBuilder.Entity<AppUser>()
                .HasOne(u => u.RefreshToken)
                .WithOne(rt => rt.User)
                .HasForeignKey<RefreshToken>(rt => rt.UserId);

            // Configure one-to-many relationship between Dorm and Floor
            modelBuilder.Entity<Dorm>()
                .HasMany(d => d.Floors)
                .WithOne(f => f.Dorm)
                .HasForeignKey(f => f.DormId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookingService>()
             .HasKey(bs => bs.Id);

            modelBuilder.Entity<BookingService>()
                .HasIndex(bs => new { bs.BookingId, bs.ServiceId });


            // Configure one-to-many relationship between Floor and House
            modelBuilder.Entity<Floor>()
                .HasMany(f => f.Houses)
                .WithOne(h => h.Floor)
                .HasForeignKey(h => h.FloorId);

            // Configure one-to-many relationship between House and Room
            modelBuilder.Entity<House>()
                .HasMany(h => h.Rooms)
                .WithOne(r => r.House)
                .HasForeignKey(r => r.HouseId);

            //Order - User (One-to-Many)
            modelBuilder.Entity<Order>()
           .HasOne(o => o.User)
           .WithMany(u => u.Orders)
           .HasForeignKey(o => o.UserId);

            // Configure one-to-many relationship between AppUser and Booking
            modelBuilder.Entity<AppUser>()
                .HasMany(a => a.Bookings)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);

            // Configure one-to-many relationship between Room and Booking
            modelBuilder.Entity<Room>()
                .HasMany(r => r.Bookings)
                .WithOne(b => b.Room)
                .HasForeignKey(b => b.RoomId);

            // Balance - User (One-to-One)
            modelBuilder.Entity<Balance>()
                .HasOne(b => b.User)
                .WithOne(u => u.Balance)
                .HasForeignKey<Balance>(b => b.UserId);

            // Configure varchar(max) for Picture
            modelBuilder.Entity<AppUser>()
                .Property(u => u.Picture)
                .HasColumnType("varchar(max)");


        }


    }
}