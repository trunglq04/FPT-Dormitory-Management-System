using Microsoft.AspNetCore.Identity;

namespace DMS_API.Models.Domain
{
    public class AppUser : IdentityUser<Guid>
    {
        public string? FirstName { get; set; } 
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public int? isCompletedInfo { get; set; } = 0;

        public Balance? Balance { get; set; }
        public ICollection<Service>? Services { get; set; }
    }
}
