using KralInsaat.Common.DTOs.ProductImages;

namespace KralInsaat.Services.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveAsync(FileUploadDTO model, string rootPath, string folder);
    }
}
