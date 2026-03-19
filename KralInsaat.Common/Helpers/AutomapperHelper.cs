using KralInsaat.Common.Entities;
using KralInsaat.Common.Enums;

namespace KralInsaat.Common.Helpers
{
    public class AutomapperHelper
    {
        public static object? GetParameterValue(ProductParameterEntity src)
        {
            if (src.Parameter == null)
                return null;

            return src.Parameter.ParameterDataType switch
            {
                ParameterDataTypeEnum.Int => src.IntValue,
                ParameterDataTypeEnum.Decimal => src.DecimalValue,
                ParameterDataTypeEnum.Bool => src.BoolValue,
                ParameterDataTypeEnum.String => src.StringValue,
                _ => null
            };
        }
    }
}
