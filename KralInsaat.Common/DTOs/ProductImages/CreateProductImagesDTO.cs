using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.DTOs.ProductImages
{
    public class CreateProductImagesDTO
    {
        [Required]
        public FileUploadDto File { get; set; }
        public bool IsCoverImage { get; set; }
    }
}
