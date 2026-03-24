namespace KralInsaat.Common.DTOs.Pagination
{
    public class PaginationRequestDTO
    {
        private int MaxPageSize { get; set; } = 100;
        public int CurrentPage { get; set; } = 1;
        private int _pageSize { get; set; } = 10;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }
    }
}
