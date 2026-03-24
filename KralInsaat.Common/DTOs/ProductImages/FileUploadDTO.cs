namespace KralInsaat.Common.DTOs.ProductImages
{
    public class FileUploadDTO
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public long Length { get; set; }
        public Stream Content { get; set; }
        public bool IsCoverImage { get; set; }
    }
}