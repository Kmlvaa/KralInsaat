using KralInsaat.Common.Entities.Base;

namespace KralInsaat.Common.Entities
{
    public class SocialMediaAccountEntity : BaseEntity
    {
        public int SocialMediaAccountId { get; set; }
        public string? SocialMediaAccountPlatform { get; set; }
        public string? SocialMediaAccountUrl { get; set; }
        public string? SocialMediaAccountIcon { get; set; }
    }
}
