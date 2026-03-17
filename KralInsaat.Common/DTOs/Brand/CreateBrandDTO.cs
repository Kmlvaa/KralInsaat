using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.DTOs.Brand
{
    public class CreateBrandDTO
    {
        [Required(ErrorMessage = "Brand name is required.")]
        public string? BrandName { get; set; }
    }
}
