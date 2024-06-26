namespace DMS_API.Models.DTO.Request
{
    public class AddRoomRequestDTO
    {
        public string Status { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public Guid HouseId { get; set; }
    }
}
