using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMS_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DMS_API.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder) {
            modelBuilder.HasDefaultSchema("FPTDMS");

            // Seeding data
            modelBuilder.Entity<Dorm>().HasData(
                new Dorm { Id = Guid.Parse("beb78b77-f52c-4193-a53a-3b3aa7a14fd9"), Name = "Dorm A" },
                new Dorm { Id = Guid.Parse("d636bf9d-5979-4b6b-8803-3709d18de12c"), Name = "Dorm B" }
            );
        }
    }
}