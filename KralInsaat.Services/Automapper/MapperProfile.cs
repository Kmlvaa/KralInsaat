using AutoMapper;
using KralInsaat.Common.DTOs.Branch;
using KralInsaat.Common.DTOs.Brand;
using KralInsaat.Common.DTOs.Category;
using KralInsaat.Common.DTOs.CategoryParameter;
using KralInsaat.Common.DTOs.Company;
using KralInsaat.Common.DTOs.Faq;
using KralInsaat.Common.DTOs.Parameter;
using KralInsaat.Common.DTOs.Product;
using KralInsaat.Common.DTOs.ProductImages;
using KralInsaat.Common.DTOs.Service;
using KralInsaat.Common.DTOs.SocialMediaAccount;
using KralInsaat.Common.DTOs.Terms;
using KralInsaat.Common.Entities;
using KralInsaat.Common.ValueObjects;

namespace KralInsaat.Services.Automapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ServiceEntity, GetServiceDTO>();
            CreateMap<CreateServiceDTO, ServiceEntity>();
            CreateMap<UpdateServiceDTO, ServiceEntity>();

            CreateMap<BrandEntity, GetBrandDTO>();
            CreateMap<CreateBrandDTO, BrandEntity>();
            CreateMap<UpdateBrandDTO, BrandEntity>();

            CreateMap<CategoryEntity, GetCategoryDTO>();
            CreateMap<CreateCategoryDTO, CategoryEntity>();
            CreateMap<UpdateCategoryDTO, CategoryEntity>();

            CreateMap<CompanyEntity, GetCompanyDTO>();
            CreateMap<CreateCompanyDTO, CompanyEntity>();
            CreateMap<UpdateCompanyDTO, CompanyEntity>();

            CreateMap<FaqEntity, GetFaqDTO>();
            CreateMap<CreateFaqDTO, FaqEntity>();
            CreateMap<UpdateFaqDTO, FaqEntity>();

            CreateMap<TermsEntity, GetTermsDTO>();
            CreateMap<CreateTermsDTO, TermsEntity>();
            CreateMap<UpdateTermsDTO, TermsEntity>();

            CreateMap<SocialMediaAccountEntity, GetSocialMediaAccountDTO>();
            CreateMap<CreateSocialMediaAccountDTO, SocialMediaAccountEntity>();
            CreateMap<UpdateSocialMediaAccountDTO, SocialMediaAccountEntity>();

            CreateMap<BranchEntity, GetBranchDTO>()
               .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Location.Latitude))
               .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Location.Longitude));
            CreateMap<CreateBranchDTO, BranchEntity>()
               .ForMember(dest => dest.Location, opt => opt.MapFrom(src => new Coordinates(src.Latitude, src.Longitude)));
            CreateMap<UpdateBranchDTO, BranchEntity>()
               .ForMember(dest => dest.Location, opt => opt.MapFrom(src => new Coordinates(src.Latitude, src.Longitude)));

            CreateMap<ProductEntity, GetProductDTO>();
            CreateMap<ProductEntity, GetProductDetailsDTO>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.BrandName))
                .ForMember(dest => dest.Parameters, opt => opt.MapFrom(src => src.ProductParameters));
            CreateMap<CreateProductDTO, ProductEntity>();
            CreateMap<UpdateProductDTO, ProductEntity>();

            CreateMap<ProductImagesEntity, GetProductImagesDTO>();
            CreateMap<CreateProductImagesDTO, ProductImagesEntity>();

            CreateMap<ParameterEntity, GetParameterDTO>();
            CreateMap<CreateParameterDTO, ParameterEntity>();
            CreateMap<UpdateParameterDTO, ParameterEntity>();

            CreateMap<ProductParameterEntity, GetParameterDTO>();

            CreateMap<CreateCategoryParameterDTO, CategoryParameterEntity>();
            CreateMap<CategoryParameterEntity, GetParameterDTO>()
                .ForMember(dest => dest.ParameterId,
                    opt => opt.MapFrom(src => src.ParameterId))
                .ForMember(dest => dest.ParameterName,
                    opt => opt.MapFrom(src => src.Parameter!.ParameterName))
                .ForMember(dest => dest.ParameterDataType,
                    opt => opt.MapFrom(src => src.Parameter!.ParameterDataType));

        }
    }
}
