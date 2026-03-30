namespace KralInsaat.Common.DTOs.Filter
{
    public class ProductFilterDTO
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public List<int>? BrandIds { get; set; }
        public List<int>? ParameterValueIds { get; set; }
    }
}
 