using AutoMapper;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Shared.Dtos.ProductDtos;

namespace WarehouseSystemAnalyst.Shared.Dtos.MappingProfiles
{
    public class ProductProfiles : Profile
    {
        public ProductProfiles()
        {
            CreateMap<Batch, BatchDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDto>().ReverseMap();
            CreateMap<Mesure, MesureDto>().ReverseMap();
            CreateMap<Package, PackageDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductItem, ProductItemDto>().ReverseMap();
            CreateMap<ProductMesures, ProductMesureDto>().ReverseMap();
            CreateMap<ProductPackages, ProductPackageDto>().ReverseMap();
        }
    }
}