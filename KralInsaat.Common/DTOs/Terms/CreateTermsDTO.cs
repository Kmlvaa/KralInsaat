using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.DTOs.Terms
{
    public class CreateTermsDTO
    {
        [Required(ErrorMessage = "Terms is required.")]
        public string? TermsDescription { get; set; }
    }
}
