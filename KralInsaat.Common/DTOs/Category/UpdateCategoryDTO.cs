using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.DTOs.Category
{
    public class UpdateCategoryDTO
    {
        public string? CategoryName { get; set; }
        [Url(ErrorMessage = "Category cover image must be a valid URL.")]
        public string? CategoryCoverImage { get; set; }
    }
}
