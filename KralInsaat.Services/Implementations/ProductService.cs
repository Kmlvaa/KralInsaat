using AutoMapper;
using KralInsaat.Common.DTOs.Pagination;
using KralInsaat.Common.DTOs.Parameter;
using KralInsaat.Common.DTOs.Product;
using KralInsaat.Common.DTOs.ProductImages;
using KralInsaat.Common.DTOs.ProductParameter;
using KralInsaat.Common.Entities;
using KralInsaat.Common.Enums;
using KralInsaat.Common.Exceptions;
using KralInsaat.Db;
using KralInsaat.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KralInsaat.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;
        private readonly IFileService _fileService;
        private readonly IPaginationService _paginationService;
        public ProductService(IMapper mapper, AppDbContext appDbContext, IFileService fileService, IPaginationService paginationService)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
            _fileService = fileService;
            _paginationService = paginationService;
        }

        public async Task<PaginationResultDTO<GetProductDTO>> GetAllProductsAsync(PaginationRequestDTO pagination)
        {
            var products = _appDbContext.Products
                .Include(x => x.ProductImages)
                .AsNoTracking()
                .AsQueryable();

            //var dto = _mapper.Map<List<GetProductDTO>>(products);

            var pagedResult = await _paginationService.GetPagedResultAsync<ProductEntity, GetProductDTO>(products, pagination.CurrentPage, pagination.PageSize);

            return pagedResult;
        }

        public async Task<GetProductDetailsDTO> GetProductByIdAsync(int productId)
        {
            var product = await _appDbContext.Products
                .Include (x => x.ProductImages)
                .Include(p => p.ProductParameters)
                    .ThenInclude(pp => pp.Parameter)
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProductId == productId) ?? throw new NotFoundException("Product not found");

            var dto = new GetProductDetailsDTO
            {
                ProductId = product.ProductId,
                CategoryId = product.CategoryId,
                BrandName = product.Brand.BrandName,
                CategoryName = product.Category.CategoryName,
                BrandId = product.BrandId,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductPrice = product.ProductPrice,
                ProductSalePrice = product.ProductSalePrice,
                CoverImage = product.ProductImages.FirstOrDefault(x => x.IsCoverImage).ProductImageUrl,
                Images = product.ProductImages.Select(x => x.ProductImageUrl).ToList(),
                Parameters = product.ProductParameters.Select(pp => new GetParameterDTO
                {
                    ParameterId = pp.ParameterId,
                    ParameterName = pp.Parameter!.ParameterName,
                    ParameterDataType = pp.Parameter.ParameterDataType,
                    Value = pp.Parameter.ParameterDataType switch
                    {
                        ParameterDataTypeEnum.Int => pp.IntValue,
                        ParameterDataTypeEnum.Decimal => pp.DecimalValue,
                        ParameterDataTypeEnum.Bool => pp.BoolValue,
                        ParameterDataTypeEnum.String => pp.StringValue,
                        _ => null
                    }
                }).ToList()
            };

            return dto;
        }

        public async Task CreateProductAsync(CreateProductDTO model, List<FileUploadDTO> images, string rootPath)
        {
            bool isCategoryExist = await _appDbContext.Categories
                .AnyAsync(x => x.CategoryId == model.CategoryId);

            if (!isCategoryExist)
                throw new NotFoundException($"Category with the id {model.CategoryId} is not found.");

            bool isBrandExist = await _appDbContext.Brands
               .AnyAsync(x => x.BrandId == model.BrandId);

            if (!isBrandExist)
                throw new NotFoundException($"Brand with the id {model.BrandId} is not found.");

            var entity = _mapper.Map<ProductEntity>(model);

            _appDbContext.Products.Add(entity);
            await _appDbContext.SaveChangesAsync();

            if (images != null)
            {
                foreach (var image in images)
                {
                    var path = await _fileService.SaveAsync(image, rootPath, "productImages");

                    await _appDbContext.ProductImages.AddAsync(new ProductImagesEntity
                    {
                        ProductId = entity.ProductId,
                        ProductImageUrl = path,
                        IsCoverImage = image.IsCoverImage
                    });
                }

                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<GetParameterDTO>> GetProductParametersAsync(int productId)
        {
            var product = await _appDbContext.Products
                .Include(x => x.ProductParameters)
                    .ThenInclude(x => x.Parameter)
                .FirstOrDefaultAsync(x => x.ProductId == productId) ?? throw new NotFoundException("Product not found");


            var parametersDto = product.ProductParameters.Select(pp => new GetParameterDTO
            {
                ParameterId = pp.ParameterId,
                ParameterName = pp.Parameter!.ParameterName,
                ParameterDataType = pp.Parameter.ParameterDataType,
                Value = pp.Parameter.ParameterDataType switch
                {
                    ParameterDataTypeEnum.Int => pp.IntValue,
                    ParameterDataTypeEnum.Decimal => pp.DecimalValue,
                    ParameterDataTypeEnum.Bool => pp.BoolValue,
                    ParameterDataTypeEnum.String => pp.StringValue,
                    _ => null
                }
            }).ToList();

            return parametersDto;
        }

        public async Task SetProductParametersAsync(int productId, SetProductParameterDTO model)
        {
            var product = await _appDbContext.Products
                .Include(x => x.ProductParameters)
                .FirstOrDefaultAsync(x => x.ProductId == productId)
                ?? throw new NotFoundException("Product not found");

            var parameterIds = await _appDbContext.CategoryParameters
             .Where(x => x.CategoryId == product.CategoryId)
             .Select(x => x.ParameterId)
             .ToListAsync();

            var parameters = await _appDbContext.Parameters
                .Where(x => parameterIds.Contains(x.ParameterId))
                .ToDictionaryAsync(x => x.ParameterId);

            foreach (var item in model.Parameters)
            {
                if (!parameters.ContainsKey(item.ParameterId))
                    throw new BadRequestException($"Parameter {item.ParameterId} not valid for this category");

                var paramEntity = parameters[item.ParameterId];

                var productParam = new ProductParameterEntity
                {
                    ProductId = productId,
                    ParameterId = item.ParameterId,
                    Parameter = paramEntity
                };

                productParam.SetValue(item.Value);

                product.ProductParameters.Add(productParam);
            }

            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(int productId, UpdateProductDTO model)
        {
            var entity = await _appDbContext.Products
                .FirstOrDefaultAsync(x => x.ProductId == productId) ?? throw new NotFoundException("Product not found");

            bool isCategoryExist = await _appDbContext.Categories
                .AnyAsync(x => x.CategoryId == model.CategoryId);

            if (!isCategoryExist)
                throw new NotFoundException($"Category with the id {model.CategoryId} is not found.");

            bool isBrandExist = await _appDbContext.Brands
               .AnyAsync(x => x.BrandId == model.BrandId);

            if (!isBrandExist)
                throw new NotFoundException($"Brand with the id {model.BrandId} is not found.");

            _mapper.Map(model, entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int productId)
        {
            var entity = await _appDbContext.Products
                .FirstOrDefaultAsync(x => x.ProductId == productId) ?? throw new NotFoundException("Product not found");

            _appDbContext.Products.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
