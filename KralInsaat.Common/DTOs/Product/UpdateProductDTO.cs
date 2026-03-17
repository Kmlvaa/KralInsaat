namespace KralInsaat.Common.DTOs.Product
{
    public class UpdateProductDTO
    {
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal? ProductPrice { get; set; }
        public decimal? ProductSalePrice { get; set; }
    }
}
