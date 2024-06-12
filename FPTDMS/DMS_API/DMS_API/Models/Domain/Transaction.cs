namespace DMS_API.Models.Domain
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid AppUserId { get; set; }
        public Guid OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        // Navigation properties
        public AppUser AppUser { get; set; }
        public Order Order { get; set; }
        public Payment Payment { get; set; }
    }
}
