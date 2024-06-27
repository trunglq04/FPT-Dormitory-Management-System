using System.ComponentModel.DataAnnotations;

namespace DMS_API.Models.DTO
{
    public class RegisterDTO
    {
        [Required]
        [DataType(DataType.Text)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
