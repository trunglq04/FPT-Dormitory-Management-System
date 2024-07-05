namespace DMS_API.Models.DTO.Request
{
    public class AddProfileInfoRequestDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Picture { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
