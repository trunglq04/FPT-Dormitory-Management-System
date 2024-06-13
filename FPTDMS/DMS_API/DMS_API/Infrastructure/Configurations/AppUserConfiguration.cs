using DMS_API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DMS_API.Infrastructure.Configurations
{
    public class AppUserConfiguration
        : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(u => u.FullName)
                .HasMaxLength(50);
            builder.Property(u => u.Description)
                .HasMaxLength(50);
            builder.Property(u => u.Picture)
                .HasMaxLength(40);
            builder.Property(u => u.Gender)
                .HasMaxLength(10);
        }
    }
}
