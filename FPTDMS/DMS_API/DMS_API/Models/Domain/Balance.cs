namespace DMS_API.Models.Domain
{
    public class Balance
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public double Amount { get; set; } = 0;

        //  Navigation properties
        public AppUser? User { get; set; } = null!;
    }
}
