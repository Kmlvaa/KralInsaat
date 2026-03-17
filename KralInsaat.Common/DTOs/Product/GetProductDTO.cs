using KralInsaat.Common.DTOs.ProductImages;

namespace KralInsaat.Common.DTOs.Product
{
    public class GetProductDTO
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal? ProductPrice { get; set; }
        public decimal? ProductSalePrice { get; set; }
        public List<GetProductImagesDTO> Images { get; set; } = [];
    }
}
