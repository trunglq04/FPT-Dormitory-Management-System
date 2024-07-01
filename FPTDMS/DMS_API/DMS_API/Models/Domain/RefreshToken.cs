namespace DMS_API.Models.Domain
{
    public class RefreshToken
    {
        public Guid Id { get; set; } // Primary key, consider using a GUID
        public string Token { get; set; } // The refresh token string
        public Guid UserId { get; set; } // Foreign key to the User table
        public DateTime ExpiryDate { get; set; } // When the token expires
        public bool IsRevoked { get; set; } // Indicates if the token is revoked
        public bool IsActive => DateTime.UtcNow <= ExpiryDate && !IsRevoked; // Checks if the token is active

        // Navigation property to the User
        public virtual AppUser User { get; set; }
    }
}
