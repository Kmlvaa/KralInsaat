using KralInsaat.Common.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.Entities
{
    public class FaqEntity : BaseEntity
    {
        [Key]
        public int FaqId { get; set; }
        public string? FaqQuestion { get; set; }
        public string? FaqAnswer { get; set; }
    }
}
