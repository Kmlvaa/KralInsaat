using KralInsaat.Common.Entities.Base;
using System.ComponentModel.DataAnnotations;
namespace KralInsaat.Common.Entities
{
    public class CompanyEntity : BaseEntity
    {
        [Key]
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyDescription { get; set; }
        public string? CompanyLogo { get; set; }
    }
}
 