namespace KralInsaat.Common.DTOs.ProductImages;
public class FileUploadDto
{
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public Stream Content { get; set; }
    public long Length { get; set; }
}