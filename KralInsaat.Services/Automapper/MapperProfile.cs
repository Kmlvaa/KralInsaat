using AutoMapper;
using KralInsaat.Common.DTOs.Brand;
using KralInsaat.Common.DTOs.Category;
using KralInsaat.Common.DTOs.Company;
using KralInsaat.Common.DTOs.Faq;
using KralInsaat.Common.DTOs.Service;
using KralInsaat.Common.DTOs.SocialMediaAccount;
using KralInsaat.Common.DTOs.Terms;
using KralInsaat.Common.Entities;

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
        }
    }
}
