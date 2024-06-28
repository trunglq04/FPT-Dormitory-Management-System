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

            //Seeding a Roles to AspNetRoles table
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole { 
                    Id = Guid.Parse("2c5e174e-3b0e-446f-86af-483d56fd7210"), 
                    Name = "Administrator", 
                    NormalizedName = "Administrator".ToUpper() 
                }
            );
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole { 
                    Id = Guid.Parse("0da24f70-3cc9-44b1-a48e-aa9d93635514"), 
                    Name = "Client", 
                    NormalizedName = "Client".ToUpper() 
                }
            );


            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<IdentityUser>();


            //Seeding the User to AspNetUsers table
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"), // primary key
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    FirstName = "Admin",
                    LastName = "Admin",
                    Gender = "Male",
                    Email = "admin@fpt.vn",
                    NormalizedEmail = "ADMIN@FPT.VN",
                    PasswordHash = hasher.HashPassword(null, "@Admin123"),
                    isCompletedInfo = 1
                },
                new AppUser
                {
                    Id = Guid.Parse("1fb571fb-110d-438a-9ba8-9a2df842af6b"), // primary key
                    UserName = "client",
                    NormalizedUserName = "CLIENT",
                    FirstName = "User",
                    LastName = "Normal",
                    Gender = "Female",
                    Email = "client@fpt.vn",
                    NormalizedEmail = "CLIENT@FPT.VN",
                    PasswordHash = hasher.HashPassword(null, "@Client123"),
                    isCompletedInfo = 1
                }
            );


            //Seeding the relation between our user and role to AspNetUserRoles table
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = Guid.Parse("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                    UserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = Guid.Parse("0da24f70-3cc9-44b1-a48e-aa9d93635514"),
                    UserId = Guid.Parse("1fb571fb-110d-438a-9ba8-9a2df842af6b")
                }
            );


            //var password = new PasswordHasher<AppUser>();
            //var hashedAdmin = password.HashPassword(admin, "@AdminFPT999");
            //var hashedClient = password.HashPassword(client, "@ClientFPT999");
            //admin.PasswordHash = hashedAdmin;
            //client.PasswordHash = hashedClient;


            //modelBuilder.Entity<AppUser>().HasData(
            //    admin,
            //    client
            //);

            modelBuilder.Entity<Balance>().HasData(
                new Balance { 
                    Id = Guid.Parse("c8eb5899-6008-4d51-8e8d-1c95680eb331"), 
                    UserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    Amount = 9999999
                },
                new Balance { 
                    Id = Guid.Parse("2fdbc0f7-4dc0-45ba-abb6-0869ec6f7111"), 
                    UserId = Guid.Parse("1fb571fb-110d-438a-9ba8-9a2df842af6b"),
                    Amount = 1111
                }

            );
        }
    }
}