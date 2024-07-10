namespace DMS_API.Models.DTO.Request
{
    public class AddHouseRequestDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int Capacity { get; set; }
        public Guid FloorId { get; set; }
        public Guid DormId { get; set; }
    }
}
