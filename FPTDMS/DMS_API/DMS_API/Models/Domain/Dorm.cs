namespace DMS_API.Models.Domain
{
    public class Dorm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //  Navigation properties
        public ICollection<Floor> Floors { get; set; }
        public ICollection<House> Houses { get; set; }
    }
}
