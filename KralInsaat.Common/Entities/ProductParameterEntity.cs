using KralInsaat.Common.Entities.Base;
using KralInsaat.Common.Enums;
using KralInsaat.Common.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

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

            try
            {
                switch (Parameter.ParameterDataType)
                {
                    case ParameterDataTypeEnum.Int:
                        if (value is JsonElement jeInt && jeInt.ValueKind == JsonValueKind.Number)
                            IntValue = jeInt.GetInt32();
                        else
                            IntValue = Convert.ToInt32(value);
                        break;

                    case ParameterDataTypeEnum.Decimal:
                        if (value is JsonElement jeDec && jeDec.ValueKind == JsonValueKind.Number)
                            DecimalValue = jeDec.GetDecimal();
                        else
                            DecimalValue = Convert.ToDecimal(value);
                        break;

                    case ParameterDataTypeEnum.Bool:
                        if (value is JsonElement jeBool && jeBool.ValueKind == JsonValueKind.True)
                            BoolValue = true;
                        else if (value is JsonElement jeBool2 && jeBool2.ValueKind == JsonValueKind.False)
                            BoolValue = false;
                        else
                            BoolValue = Convert.ToBoolean(value);
                        break;

                    case ParameterDataTypeEnum.String:
                        if (value is JsonElement jeStr && jeStr.ValueKind == JsonValueKind.String)
                            StringValue = jeStr.GetString();
                        else
                            StringValue = Convert.ToString(value);
                        break;

                    default:
                        throw new NotSupportedException();
                }
            }
            catch (Exception ex)
            {
                throw new BadRequestException($"Invalid value for parameter {Parameter.ParameterName}: {ex.Message}");
            }
        }
    }
}
