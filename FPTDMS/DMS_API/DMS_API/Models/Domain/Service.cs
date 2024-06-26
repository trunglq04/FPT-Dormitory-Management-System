namespace DMS_API.Models.Domain
{
    public class Service
    {
        public Guid Id { get; set; }
        public DateTime BookingDate { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }


        //Navigation properties
        public Guid UserId { get; set; }
        public AppUser User { get; set; }

        public Guid RoomId { get; set; }
        public Room Room { get; set; }
    }
}
