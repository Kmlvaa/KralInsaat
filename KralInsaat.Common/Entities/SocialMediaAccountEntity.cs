using KralInsaat.Common.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.Entities
{
    public class SocialMediaAccountEntity : BaseEntity
    {
        [Key]
        public int SocialMediaAccountId { get; set; }
        public string? SocialMediaAccountPlatform { get; set; }
        public string? SocialMediaAccountUrl { get; set; }
        public string? SocialMediaAccountIcon { get; set; }
    }
}
