using AutoMapper;
using WarehouseSystemAnalyst.Data.Models.Dtos.ProductDtos;
using WarehouseSystemAnalyst.Data.Entities.SupplyChainEntities;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;

namespace WarehouseSystemAnalyst.Mediator.MappingProfiles.ProductConfigs
{
    public class RelatedProductProfiles : Profile
    {
        public RelatedProductProfiles()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDto>().ReverseMap();
            CreateMap<Mesure, MesureDto>().ReverseMap();
            CreateMap<ProductVendor, ProductSuppliersDto>().ReverseMap();
            CreateMap<Package, PackageDto>().ReverseMap();
        }
    }
}