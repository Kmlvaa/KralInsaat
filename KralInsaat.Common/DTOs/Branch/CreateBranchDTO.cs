using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.DTOs.Branch
{
    public class CreateBranchDTO
    {
        [Required(ErrorMessage = "Company ID field is required.")]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "Branch name field is required.")]
        public string? BranchName { get; set; }
        [Required(ErrorMessage = "Branch address field is required.")]
        public string? BranchAddress { get; set; }
        [Required(ErrorMessage = "Branch phone number field is required.")]
        public string? BranchPhoneNumber { get; set; }
        public string? BranchWhatsappNumber { get; set; }
        public string? BranchEmail { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
