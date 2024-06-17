namespace DMS_API.Data.Models.Domain
{
    public class Dorm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        //  Navigation properties
        public ICollection<Floor> Floors { get; set; }
    }
}
