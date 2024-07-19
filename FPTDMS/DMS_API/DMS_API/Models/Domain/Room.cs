namespace DMS_API.Models.Domain
{
    public class Room
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string? Description { get; set; }
        public int Capacity { get; set; }
        public Guid HouseId { get; set; }
   
        public string RoomType { get; set; }
        public float Price { get; set; }


        public House House { get; set; }
        public ICollection<Service>? Services { get; set; }
        public ICollection<Booking>? Bookings { get; set; }


    }
}
