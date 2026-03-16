namespace KralInsaat.Common.Entities.Base
{
    public class BaseEntity : IBaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
