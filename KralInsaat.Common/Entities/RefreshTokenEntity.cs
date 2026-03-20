using KralInsaat.Common.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.Entities
{
    public class RefreshTokenEntity : BaseEntity
    {
        [Key]
        public int RefreshTokenId { get; set; }
        public int? UserId { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpires { get; set; }
        public bool IsRefrehTokenRevoked { get; set; } = false;
    }
}
  