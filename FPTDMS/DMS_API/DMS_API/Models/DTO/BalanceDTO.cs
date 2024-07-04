namespace DMS_API.Models.DTO
{
    public class BalanceDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public float Amount { get; set; } = 0;
        //navigation properties
        public AppUserDTO User { get; set; }
    }
}
