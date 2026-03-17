namespace KralInsaat.Common.DTOs.Branch
{
    public class UpdateBranchDTO
    {
        public int CompanyId { get; set; }
        public string? BranchName { get; set; }
        public string? BranchAddress { get; set; }
        public string? BranchPhoneNumber { get; set; }
        public string? BranchWhatsappNumber { get; set; }
        public string? BranchEmail { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
