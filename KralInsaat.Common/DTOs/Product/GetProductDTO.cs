namespace KralInsaat.Common.DTOs.Product
{
    public class GetProductDTO
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double? ProductPrice { get; set; }
        public double? ProductSalePrice { get; set; }
        //public List<GetProductImagesDTO> ProductImages { get; set; } = [];
    }
}
