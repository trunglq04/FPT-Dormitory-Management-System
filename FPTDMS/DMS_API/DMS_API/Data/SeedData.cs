using DMS_API.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DMS_API.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("FPTDMS");

            // Seeding data

            // modelBuilder.Entity<Dorm>().HasData(
            //     new Dorm { Id = Guid.Parse("beb78b77-f52c-4193-a53a-3b3aa7a14fd9"), Name = "Dorm A" },
            //     new Dorm { Id = Guid.Parse("d636bf9d-5979-4b6b-8803-3709d18de12c"), Name = "Dorm B" }
            // );
            var admin = new AppUser
            {
                Id = Guid.Parse("0bebe4b6-b7ed-42f1-b9b7-776410deabce"),
                FirstName = "Admin",
                LastName = "Admin",
                Gender = "Male",
                UserName = "admin",
                Email = "admin@fpt.vn",
                NormalizedEmail = "ADMIN@FPT.VN"
            };

            var client = new AppUser
            {
                Id = Guid.Parse("d88e5d33-11e5-4fb2-a039-5b3a9ea9bab9"),
                FirstName = "User",
                LastName = "Normal",
                Gender = "Female",
                UserName = "client",
                Email = "client@fpt.vn",
                NormalizedEmail = "CLIENT@FPT.VN"
            };
            var password = new PasswordHasher<AppUser>();
            var hashedAdmin = password.HashPassword(admin, "@AdminFPT999");
            var hashedClient = password.HashPassword(client, "@ClientFPT999");
            admin.PasswordHash = hashedAdmin;
            client.PasswordHash = hashedClient;

            modelBuilder.Entity<AppUser>().HasData(
                admin,
                client
            );

            modelBuilder.Entity<Balance>().HasData(
                new Balance { 
                    Id = Guid.Parse("c8eb5899-6008-4d51-8e8d-1c95680eb331"), 
                    UserId = Guid.Parse("0bebe4b6-b7ed-42f1-b9b7-776410deabce"),
                    Amount = 9999999
                },
                new Balance { 
                    Id = Guid.Parse("2fdbc0f7-4dc0-45ba-abb6-0869ec6f7111"), 
                    UserId = Guid.Parse("d88e5d33-11e5-4fb2-a039-5b3a9ea9bab9"),
                    Amount = 1111
                }

            );
        }
    }
}