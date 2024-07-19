namespace DMS_API.Models.DTO
{
    public class HouseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Capacity { get; set; }
        public string FloorName { get; set; }
    }
}
