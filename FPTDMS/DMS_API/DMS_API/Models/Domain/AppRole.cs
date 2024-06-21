using Microsoft.AspNetCore.Identity;

namespace DMS_API.Models.Domain
{
    public class AppRole : IdentityRole<Guid>
    {
        public string? Description { get; set; }
    }
}
