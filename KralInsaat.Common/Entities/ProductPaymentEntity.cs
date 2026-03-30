using KralInsaat.Common.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.Entities
{
    public class ProductPaymentEntity : BaseEntity
    {
        [Key]
        public int ProductPaymentId { get; set; }
        public int ProductId { get; set; }
        public ProductEntity? Product { get; set; }
        public int PaymentCardId { get; set; }
        public PaymentCardEntity? PaymentCard { get; set; }
    }
}
