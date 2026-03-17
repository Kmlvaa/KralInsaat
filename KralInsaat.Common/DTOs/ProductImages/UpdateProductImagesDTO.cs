using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.DTOs.ProductImages
{
    public class UpdateProductImagesDTO
    {
        [Url(ErrorMessage = "Category cover image must be a valid URL.")]
        public string? ProductImageUrl { get; set; }
        public bool IsCoverImage { get; set; }
    }
}
