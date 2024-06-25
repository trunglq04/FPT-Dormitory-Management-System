namespace DMS_API.Models.DTO
{
    public class HouseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int Capacity { get; set; }
        public string FloorName { get; set; }

        //// Floor DTO
        //public FloorDto Floor { get; set; }

        // Nested DTOs for related entities
        public List<RoomDTO> Rooms { get; set; }
    }
}
