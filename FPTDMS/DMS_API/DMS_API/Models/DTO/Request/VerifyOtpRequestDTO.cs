namespace DMS_API.Models.DTO.Request
{
    public class VerifyOtpRequestDTO
    {
        public string Email { get; set; }
        public string Otp { get; set; }
    }
}
