namespace DMS_API.Models.DTO.Request
{
    public class CreateBookingRequestDTO
    {
        public Guid UserId { get; set; }
        public Guid RoomId { get; set; }
        public string RoomType { get; set; }
    }
}
