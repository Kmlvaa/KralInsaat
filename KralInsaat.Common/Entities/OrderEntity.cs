using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.Entities
{
    public class OrderEntity
    {
        [Key]
        public int OrderId { get; set; }
        public int PaymentMethodId { get; set; }
        public PaymentMethodEntity? PaymentMethod { get; set; }
        public int InstallmentPlanId { get; set; }
        public InstallmentPlanEntity? InstallmentPlan { get; set; }
        public List<OrderItemEntity> OrderItems { get; set; } = [];

        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerAddress { get; set; }
    }
}
  