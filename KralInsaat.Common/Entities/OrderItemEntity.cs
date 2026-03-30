using KralInsaat.Common.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.Entities
{
    public class OrderItemEntity : BaseEntity
    {
        [Key]
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public OrderEntity? Order { get; set; }
        public int ProductId { get; set; }
        public ProductEntity? Product { get; set; }

        public int OrderItemQuantity { get; set; }
        public decimal OrderItemPrice { get; set; }
    }
}
