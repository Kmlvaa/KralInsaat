using KralInsaat.Common.DTOs.Brand;
using KralInsaat.Common.DTOs.Product;

namespace KralInsaat.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<GetProductDTO>> GetAllProductsAsync();
        Task<GetProductDTO> GetProductByIdAsync(int productId);
        Task CreateProductAsync(CreateProductDTO model);
        Task UpdateProductAsync(int productId, UpdateProductDTO model);
        Task DeleteProductAsync(int productId);
    }
} 
