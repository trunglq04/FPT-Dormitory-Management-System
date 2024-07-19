namespace DMS_API.Models.DTO
{
    public class AppUserDTO
    {
        public string? Id { get; set; }     // hidden in FE
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public string? PhoneNumber { get; set; }
        public BalanceDTO? Balance { get; set; }

    }
}
