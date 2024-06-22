namespace DMS_API.Models.Domain
{
    public class House
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int Capacity { get; set; }
        public Guid FloorId { get; set; }

        public Floor Floor { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
