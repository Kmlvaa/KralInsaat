using KralInsaat.Common.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.Entities
{
    public class ProductEntity : BaseEntity
    {
        [Key]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }
        public int BrandId { get; set; }
        public BrandEntity? Brand { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public double? ProductPrice { get; set; }
        public double? ProductSalePrice { get; set; }
        public List<ProductImagesEntity> Images { get; set; } = [];
    } 
}
