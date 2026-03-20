using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.DTOs.Auth
{
    public class LoginRequestDTO
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 length of characters.")]
        public string Password { get; set; }
    }
}
