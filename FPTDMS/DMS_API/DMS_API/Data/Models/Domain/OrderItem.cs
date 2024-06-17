namespace DMS_API.Data.Models.Domain
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ServiceId { get; set; }
        public string Status { get; set; } = "pending";
        public float Price { get; set; }

        // Navigation properties
        public Order Order { get; set; }
        public Service Service { get; set; }
    }
}
