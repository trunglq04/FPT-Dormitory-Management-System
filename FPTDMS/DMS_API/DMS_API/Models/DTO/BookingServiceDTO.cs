namespace DMS_API.Models.DTO
{
    public class BookingServiceDTO
    {
        public string ServiceName { get; set; }
        public float ServicePrice { get; set; }
        public string ServiceDescription { get; set; }
        public DateTime DateRequest { get; set; }
        public int UsageCount { get; set; } 
        public string RoomName { get; set; }
        public string UserName { get; set; }
        public string HouseName { get; set; }
        public string Status { get; set; }

    }
}
