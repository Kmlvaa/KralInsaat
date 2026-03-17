using KralInsaat.Common.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.Entities
{
    public class ProductImagesEntity : BaseEntity
    {
        [Key]
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public ProductEntity? Product { get; set; }
        public string? ProductImageUrl { get; set; }
        public bool IsCoverImage { get; set; }
    }
}
