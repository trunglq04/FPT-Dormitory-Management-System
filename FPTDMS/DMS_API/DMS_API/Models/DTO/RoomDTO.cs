namespace DMS_API.Models.DTO
{
    public class RoomDTO
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public Guid HouseId { get; set; }

        // House DTO
        //public HouseDto House { get; set; }
    }
}
