namespace KralInsaat.Common.DTOs.Service
{
    public class GetServiceDTO
    {
        public int ServiceId { get; set; }
        public string? ServiceTitle { get; set; }
        public string? ServiceSubTitle { get; set; }
        public string? ServiceDescription { get; set; }
        public string? ServiceIcon { get; set; }
    }
}
