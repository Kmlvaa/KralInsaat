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
        public GetCategoryDTO? CategoryName { get; set; }
        public int BrandId { get; set; }
        public GetBrandDTO? BrandName { get; set; } 
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public double? ProductPrice { get; set; }
        public double? ProductSalePrice { get; set; }
        public List<GetParameterDTO> Parameters { get; set; } = [];
        //public List<GetProductImagesDTO> Images { get; set; } = [];
    }
}
