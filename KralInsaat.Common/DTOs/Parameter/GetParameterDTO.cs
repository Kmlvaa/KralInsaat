using KralInsaat.Common.Enums;

namespace KralInsaat.Common.DTOs.Parameter
{
    public class GetParameterDTO
    {
        public int ParameterId { get; set; }
        public string ParameterName { get; set; }
        public ParameterDataTypeEnum ParameterDataType { get; set; }
        public object? Value { get; set; }
    }
}
