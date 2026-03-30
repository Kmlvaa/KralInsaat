using KralInsaat.Common.Entities.Base;
using KralInsaat.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.Entities
{
    public class PaymentCardEntity : BaseEntity
    {
        [Key]
        public int PaymentCardId { get; set; }
        public string? PaymentCardName { get; set; }
        public string? PaymentCardLogoUrl { get; set; }
        public PaymentCardTypeEnum PaymentCardType { get; set; }
        public List<InstallmentPlanEntity> InstallmentPlans { get; set; } = [];
        public List<ProductPaymentEntity> ProductPayments { get; set; } = [];
    }
}
