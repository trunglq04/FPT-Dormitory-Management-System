using DMS_API.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DMS_API.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("FPTDMS");

            // Seeding Roles
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole { Id = Guid.Parse("2c5e174e-3b0e-446f-86af-483d56fd7210"), Name = "Administrator", NormalizedName = "ADMINISTRATOR" },
                new AppRole { Id = Guid.Parse("0da24f70-3cc9-44b1-a48e-aa9d93635514"), Name = "Client", NormalizedName = "CLIENT" }
            );

            // Seeding Users
            var hasher = new PasswordHasher<IdentityUser>();
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    FirstName = "Admin",
                    LastName = "Admin",
                    Gender = "Male",
                    Email = "admin@fpt.edu.vn",
                    NormalizedEmail = "ADMIN@FPT.EDU.VN",
                    PasswordHash = hasher.HashPassword(null, "@Admin123"),
                    LockoutEnabled = false
                },
                new AppUser
                {
                    Id = Guid.Parse("1fb571fb-110d-438a-9ba8-9a2df842af6b"),
                    UserName = "client",
                    NormalizedUserName = "CLIENT",
                    FirstName = "User",
                    LastName = "Normal",
                    Gender = "Female",
                    Email = "client@fpt.edu.vn",
                    NormalizedEmail = "CLIENT@FPT.EDU.VN",
                    PasswordHash = hasher.HashPassword(null, "@Client123"),
                }
            );

            // Seeding UserRoles
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

            // Seeding Balance
            modelBuilder.Entity<Balance>().HasData(
                new Balance
                {
                    Id = Guid.Parse("c8eb5899-6008-4d51-8e8d-1c95680eb331"),
                    UserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    Amount = 9999999
                },
                new Balance
                {
                    Id = Guid.Parse("2fdbc0f7-4dc0-45ba-abb6-0869ec6f7111"),
                    UserId = Guid.Parse("1fb571fb-110d-438a-9ba8-9a2df842af6b"),
                    Amount = 1111
                }
            );

            // Seeding Dorms
            modelBuilder.Entity<Dorm>().HasData(
                new Dorm { Id = Guid.Parse("beb78b77-f52c-4193-a53a-3b3aa7a14fd9"), Name = "Dorm A", Description = "Description for Dorm A" },
                new Dorm { Id = Guid.Parse("d636bf9d-5979-4b6b-8803-3709d18de12c"), Name = "Dorm B", Description = "Description for Dorm B" }
            );

            // Seeding Floors
            var floors = new List<Floor>();
            for (int i = 1; i <= 5; i++)
            {
                floors.Add(new Floor
                {
                    Id = Guid.NewGuid(),
                    Name = $"Floor {i}",
                    DormId = Guid.Parse("beb78b77-f52c-4193-a53a-3b3aa7a14fd9"),
                    Description = $"Description for Floor {i} in Dorm A"
                });
                floors.Add(new Floor
                {
                    Id = Guid.NewGuid(),
                    Name = $"Floor {i}",
                    DormId = Guid.Parse("d636bf9d-5979-4b6b-8803-3709d18de12c"),
                    Description = $"Description for Floor {i} in Dorm B"
                });
            }
            modelBuilder.Entity<Floor>().HasData(floors);

            // Seeding Houses and Rooms
            var houses = new List<House>();
            var rooms = new List<Room>();
            foreach (var floor in floors)
            {
                int floorNumber = int.Parse(floor.Name.Split(' ')[1]);
                for (int j = 1; j <= 6; j++)
                {
                    var houseId = Guid.NewGuid();
                    houses.Add(new House
                    {
                        Id = houseId,
                        Name = $"P.{floorNumber}0{j}",
                        FloorId = floor.Id,
                        Description = $"Description for House {j} on {floor.Name}",
                        Status = "Available",
                        Capacity = 13
                    });

                    rooms.Add(new Room
                    {
                        Id = Guid.NewGuid(),
                        Name = $"Room 3 Beds",
                        Status = "Available",
                        Description = "Room with 3 Beds",
                        Capacity = 3,
                        HouseId = houseId,
                        RoomType = "3 Beds",
                        Price = 1150000
                    });
                    rooms.Add(new Room
                    {
                        Id = Guid.NewGuid(),
                        Name = $"Room 4 Beds",
                        Status = "Available",
                        Description = "Room with 4 Beds",
                        Capacity = 4,
                        HouseId = houseId,
                        RoomType = "4 Beds",
                        Price = 1050000
                    });
                    rooms.Add(new Room
                    {
                        Id = Guid.NewGuid(),
                        Name = $"Room 6 Beds",
                        Status = "Available",
                        Description = "Room with 6 Beds",
                        Capacity = 6,
                        HouseId = houseId,
                        RoomType = "6 Beds",
                        Price = 850000
                    });
                }
            }
            modelBuilder.Entity<House>().HasData(houses);
            modelBuilder.Entity<Room>().HasData(rooms);
        }
    }
}