namespace DMS_API.Models.DTO.Request
{
    public class UpdateBookingRequestDTO
    {
        public Guid RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float TotalPrice { get; set; }
        public string Status { get; set; }
    }
}
