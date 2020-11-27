using AutoMapper;
using WarehouseSystemAnalyst.Data.Models.Dtos.ProductDtos;
using WarehouseSystemAnalyst.Data.Entites.ProductEntities;

namespace WarehouseSystemAnalyst.Mediator.MappingProfiles.ProductConfigs
{
    public class RelatedProductProfiles : Profile
    {
        public RelatedProductProfiles()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDto>().ReverseMap();
            CreateMap<Mesure, MesureDto>().ReverseMap();
            CreateMap<ProductSuppliers, ProductSuppliersDto>().ReverseMap();
            CreateMap<Package, PackageDto>().ReverseMap();
        }
    }
}