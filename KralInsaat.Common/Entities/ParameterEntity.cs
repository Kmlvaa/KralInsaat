using KralInsaat.Common.Entities.Base;
using KralInsaat.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.Entities
{
    public class ParameterEntity : BaseEntity
    {
        [Key]
        public int ParameterId { get; set; }
        public List<CategoryParameterEntity> CategoryParameters { get; set; } = [];
        public string ParameterName { get; set; }
        public ParameterDataTypeEnum ParameterDataType { get; set; }
    }
} 
  