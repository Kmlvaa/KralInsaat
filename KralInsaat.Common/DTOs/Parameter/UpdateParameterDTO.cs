using KralInsaat.Common.Enums;

namespace KralInsaat.Common.DTOs.Parameter
{
    public class UpdateParameterDTO
    {
        public string ParameterName { get; set; }
        public ParameterDataTypeEnum ParameterDataType { get; set; }
    }
}
