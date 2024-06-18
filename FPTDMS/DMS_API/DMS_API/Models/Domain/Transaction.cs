namespace DMS_API.Models.Domain
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid OrderId { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        // Navigation properties
        public AppUser User { get; set; }
        public Order Order { get; set; }
        public Payment Payment { get; set; }
    }
}
