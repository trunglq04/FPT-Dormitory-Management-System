namespace DMS_API.Models.DTO
{
    public class RoomDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string? Description { get; set; }
        public int Capacity { get; set; }
        public string HouseName { get; set; }
        public string FloorName { get; set; }
        public string DormName { get; set; }
        public string RoomType { get; set; }
        public float Price { get; set; }
    }
}
