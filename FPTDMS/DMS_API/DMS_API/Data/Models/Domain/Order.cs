namespace DMS_API.Data.Models.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Status { get; set; } = "pending";
        public string Description { get; set; }
        public float TotalPrice { get; set; }

        // Navigation properties
        public User User { get; set; }
    }
}
