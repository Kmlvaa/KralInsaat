using KralInsaat.Common.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.Entities
{
    public class PaymentMethodEntity : BaseEntity
    {
        [Key]
        public int PaymentMethodId { get; set; }
        public string? PaymentMethodName { get; set; }
        public string? PaymentMethodDescription { get; set; }
    }
}
