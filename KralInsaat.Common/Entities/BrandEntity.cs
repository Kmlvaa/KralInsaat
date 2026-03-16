using KralInsaat.Common.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.Entities
{
    public class BrandEntity : BaseEntity
    {
        [Key]
        public int BrandId { get; set; }
        public string? BrandName { get; set; }
    }
}
