namespace DMS_API.Models.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string OrderReference { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; } = "pending";
        public float Amount { get; set; }

        // Navigation properties
        public AppUser User { get; set; }
    }
}
