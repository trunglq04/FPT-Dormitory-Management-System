namespace DMS_API.Models.Domain
{
    public class BookingService
    {
        public int Id { get; set; }
        public Guid BookingId { get; set; }
        public Booking Booking { get; set; }
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }
        public DateTime RequestDate { get; set; }
        public int UsageCount { get; set; } = 1; 
        public string Status { get; set; } = "pending";
    }
}
