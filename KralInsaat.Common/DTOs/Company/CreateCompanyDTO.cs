using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.DTOs.Company
{
    public class CreateCompanyDTO
    {
        [Required(ErrorMessage = "Company name is required.")]
        public string? CompanyName { get; set; }
        public string? CompanyDescription { get; set; }
        [Required(ErrorMessage = "Company logo is required.")]
        public string? CompanyLogo { get; set; }
    }
}
