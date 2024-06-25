namespace DMS_API.Models.DTO
{
    public class DormDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Nested DTOs for related entities
        public List<FloorDTO> Floors { get; set; }
    }
}
