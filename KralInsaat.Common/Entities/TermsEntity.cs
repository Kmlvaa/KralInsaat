using KralInsaat.Common.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.Entities
{
    public class TermsEntity : BaseEntity
    {
        [Key]
        public int TermsId { get; set; }
        public string? TermsDescription { get; set; }   
    }
}
