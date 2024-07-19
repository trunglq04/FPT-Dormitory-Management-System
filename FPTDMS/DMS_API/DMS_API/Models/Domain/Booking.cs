namespace DMS_API.Models.Domain
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public Guid UserId { get; set; }
        public string RoomType { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float TotalPrice { get; set; }
        public string Status { get; set; } = "pending";

        public Room Room { get; set; }
        public AppUser User { get; set; }
        public ICollection<BookingService> BookingServices { get; set; }
    }
}
