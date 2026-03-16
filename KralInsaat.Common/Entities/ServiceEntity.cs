using KralInsaat.Common.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.Entities
{
    public class ServiceEntity : BaseEntity
    {
        [Key]
        public int ServiceId { get; set; }
        public string? ServiceTitle { get; set; }
        public string? ServiceSubTitle { get; set; }
        public string? ServiceDescription { get; set; }
        public string? ServiceIcon { get; set; }
    }
} 
 