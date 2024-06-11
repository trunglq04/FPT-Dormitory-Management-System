using Microsoft.AspNetCore.Identity;

namespace Models.Domain
{
    public class AppUser : IdentityUser
    {
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Pictures { get; set; }
    }
}