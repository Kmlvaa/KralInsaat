using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.DTOs.Service
{
    public class CreateServiceDTO
    {
        [Required(ErrorMessage = "Service title is required.")]
        public string? CategoryTitle { get; set; }
        [Required(ErrorMessage = "Service subtitle is required.")]
        public string? ServiceSubTitle { get; set; }
        [Required(ErrorMessage = "Service description is required.")]
        public string? ServiceDescription { get; set; }
        [Required(ErrorMessage = "Service icon is required.")]
        public string? ServiceIcon { get; set; }
    }
}
