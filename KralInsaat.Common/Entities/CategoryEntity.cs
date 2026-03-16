using KralInsaat.Common.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.Entities
{
    public class CategoryEntity : BaseEntity
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryCoverImage { get; set; }
    }
}
