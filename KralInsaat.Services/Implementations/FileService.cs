using KralInsaat.Common.DTOs.ProductImages;
using KralInsaat.Services.Interfaces;

namespace KralInsaat.Services.Implementations
{
    public class FileService : IFileService
    {
        private const long MaxSize = 2 * 1024 * 1024;

        public async Task<string> SaveAsync(FileUploadDTO file, string rootPath, string folderPath)
        {
            if (file == null || file.Length == 0)
                throw new Exception("Image is empty!");

            if (file.Length > MaxSize) 
                throw new Exception("File size cannot exceed 2MB.");

            var permittedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                throw new Exception("Invalid file type.");

            var absoluteFolderPath = Path.Combine(rootPath, folderPath);

            if (!Directory.Exists(absoluteFolderPath))
                Directory.CreateDirectory(absoluteFolderPath);

            var fileName = $"{Guid.NewGuid()}{ext}";
            var filePath = Path.Combine(absoluteFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.Content.CopyToAsync(stream);
            }

            return $"/{folderPath}/{fileName}".Replace("\\", "/");
        }
    }
}
