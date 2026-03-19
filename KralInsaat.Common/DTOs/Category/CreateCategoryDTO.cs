using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.DTOs.Category
{
    public class CreateCategoryDTO
    {
        [Required(ErrorMessage = "Category name is required.")]
        public string? CategoryName { get; set; }
        [Required(ErrorMessage = "Category cover image is required.")]
        public string? CategoryCoverImage { get; set; }
    }
}
