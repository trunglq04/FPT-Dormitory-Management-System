using DMS_API.Models.Domain;

namespace DMS_API.Models.DTO
{
    public class ServiceDTO
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public string ServiceName { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }

    }
}
