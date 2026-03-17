using KralInsaat.Common.Entities.Base;
using KralInsaat.Common.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.Entities
{
    public class BranchEntity : BaseEntity
    {
        [Key]
        public int BranchId { get; set; }
        public int CompanyId { get; set; }
        public CompanyEntity? Company { get; set; }
        public string? BranchName { get; set; }
        public string? BranchAddress { get; set; }
        public string? BranchPhoneNumber { get; set; }
        public string? BranchWhatsappNumber { get; set; }
        public string? BranchEmail { get; set; }
        public Coordinates Location { get; private set; } = null!;
        public void SetLocation(double latitude, double longitude)
        {
            Location = new Coordinates(latitude, longitude);
        }
    }
}
