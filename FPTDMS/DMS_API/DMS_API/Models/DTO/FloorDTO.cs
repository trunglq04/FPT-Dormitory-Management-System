namespace DMS_API.Models.DTO
{
    public class FloorDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DormName { get; set; }

        //// Dorm DTO
        //public DormDto Dorm { get; set; }

        // Nested DTOs for related entities
        public List<HouseDTO> Houses { get; set; }
    }
}

