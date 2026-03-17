
using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.DTOs.Product
{
    public class CreateProductDTO
    {
        [Required(ErrorMessage = "Category ID is required.")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Brand ID is required.")]
        public int BrandId { get; set; }
        [Required(ErrorMessage = "Product name is required.")]
        public string? ProductName { get; set; }
        [Required(ErrorMessage = "Product description is required.")]
        public string? ProductDescription { get; set; }
        [Required(ErrorMessage = "Product price is required.")]
        public decimal? ProductPrice { get; set; }
        public decimal? ProductSalePrice { get; set; }
    }
}
