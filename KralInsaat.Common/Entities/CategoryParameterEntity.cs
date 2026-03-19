using KralInsaat.Common.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.Entities
{
    public class CategoryParameterEntity : BaseEntity
    {
        [Key]
        public int CategoryParameterId { get; set; }
        public int CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }
        public int ParameterId { get; set; }
        public ParameterEntity? Parameter { get; set; }
    }
}
