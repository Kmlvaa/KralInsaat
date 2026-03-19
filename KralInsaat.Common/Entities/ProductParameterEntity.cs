using KralInsaat.Common.Entities.Base;
using KralInsaat.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace KralInsaat.Common.Entities
{
    public class ProductParameterEntity : BaseEntity
    {
        [Key]
        public int ProductParameterId { get; set; }
        public int ProductId { get; set; }
        public ProductEntity? Product { get; set; }
        public int ParameterId { get; set; }
        public ParameterEntity? Parameter { get; set; }
        public int? IntValue { get; set; }
        public decimal? DecimalValue { get; set; }
        public bool? BoolValue { get; set; }
        public string? StringValue { get; set; }
        public void SetValue(object value)
        {
            if (Parameter == null)
                throw new InvalidOperationException("Parameter must be loaded");

            IntValue = null;
            DecimalValue = null;
            BoolValue = null;
            StringValue = null;

            switch (Parameter.ParameterDataType)
            {
                case ParameterDataTypeEnum.Int:
                    IntValue = Convert.ToInt32(value);
                    break;

                case ParameterDataTypeEnum.Decimal:
                    DecimalValue = Convert.ToDecimal(value);
                    break;

                case ParameterDataTypeEnum.Bool:
                    BoolValue = Convert.ToBoolean(value);
                    break;

                case ParameterDataTypeEnum.String:
                    StringValue = Convert.ToString(value);
                    break;

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
