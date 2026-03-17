using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.DTOs.Faq
{
    public class CreateFaqDTO
    {
        [Required(ErrorMessage = "FAQ question is required.")]
        public string? FaqQuestion { get; set; }
        [Required(ErrorMessage = "FAQ answer is required.")]
        public string? FaqAnswer { get; set; }
    }
}
