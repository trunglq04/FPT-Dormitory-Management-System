namespace DMS_API.Models.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid AppUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Status { get; set; } = "pending";
        public string Description { get; set; }
        public float TotalPrice { get; set; }

        // Navigation properties
        public AppUser AppUser { get; set; }
    }
}
