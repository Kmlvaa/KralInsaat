namespace KralInsaat.Common.DTOs.ProductImages
{
    public class GetProductImagesDTO
    {
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public string? ProductImageUrl { get; set; }
        public bool IsCoverImage { get; set; }
    }
}
