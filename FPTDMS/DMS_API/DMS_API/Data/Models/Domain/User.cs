using Microsoft.AspNetCore.Identity;

namespace DMS_API.Data.Models.Domain
{
    public class User : IdentityUser
    {
        public string? FullName { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }

        public Guid BalanceId { get; set; }

    }
}
