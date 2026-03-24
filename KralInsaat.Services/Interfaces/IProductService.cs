using KralInsaat.Common.DTOs.Parameter;
using KralInsaat.Common.DTOs.Product;
using KralInsaat.Common.DTOs.ProductImages;
using KralInsaat.Common.DTOs.ProductParameter;

namespace KralInsaat.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<GetProductDTO>> GetAllProductsAsync();
        Task<GetProductDetailsDTO> GetProductByIdAsync(int productId);
        Task CreateProductAsync(CreateProductDTO model, List<FileUploadDTO> files, string rootPath);
        Task UpdateProductAsync(int productId, UpdateProductDTO model); 
        Task DeleteProductAsync(int productId);
        Task<List<GetParameterDTO>> GetProductParametersAsync(int productId);
        Task SetProductParametersAsync(int productId, SetProductParameterDTO model);
    }
} 
