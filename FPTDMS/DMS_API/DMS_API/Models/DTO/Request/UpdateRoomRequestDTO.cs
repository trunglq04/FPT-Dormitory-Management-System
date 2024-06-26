namespace DMS_API.Models.DTO.Request
{
    public class UpdateRoomRequestDTO
    {
        public string Status { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public Guid HouseId { get; set; }
    }
}
