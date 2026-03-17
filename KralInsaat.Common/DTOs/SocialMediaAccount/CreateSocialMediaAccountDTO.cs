using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.DTOs.SocialMediaAccount
{
    public class CreateSocialMediaAccountDTO
    {
        [Required(ErrorMessage = "Social media account platform is required.")]
        public string? SocialMediaAccountPlatform { get; set; }
        [Required(ErrorMessage = "Social media account url is required.")]
        public string? SocialMediaAccountUrl { get; set; }
        [Required(ErrorMessage = "Social media account icon is required.")]
        public string? SocialMediaAccountIcon { get; set; }
    }
}
