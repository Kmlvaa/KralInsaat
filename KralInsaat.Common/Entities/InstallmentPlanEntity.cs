using KralInsaat.Common.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.Entities
{
    public class InstallmentPlanEntity : BaseEntity
    {
        [Key]
        public int InstallmentPlanId { get; set; }
        public int PaymentCardId { get; set; }
        public PaymentCardEntity? PaymentCard { get; set; }

        public int InstallmentPlanMonths { get; set; }
        public decimal InterestRate { get; set; }
        public string? InstallmentPlanImage { get; set; }
    }
}
