using KralInsaat.Common.DTOs.Brand;
using KralInsaat.Common.DTOs.Category;
using KralInsaat.Common.DTOs.Parameter;
using KralInsaat.Common.DTOs.ProductImages;

namespace KralInsaat.Common.DTOs.Product
{
    public class GetProductDetailsDTO
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string? ProductName { get; set; } 
        public string? ProductDescription { get; set; }
        public double? ProductPrice { get; set; }
        public double? ProductSalePrice { get; set; }
        public string? CoverImage { get; set; }
        public List<string> Images { get; set; } = [];
        public List<GetParameterDTO> Parameters { get; set; } = [];
    }
}
