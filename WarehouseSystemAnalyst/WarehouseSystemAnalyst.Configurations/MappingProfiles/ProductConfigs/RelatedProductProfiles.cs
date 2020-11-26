using AutoMapper;
using WarehouseSystemAnalyst.Data.Models.Data.ProductModels;
using WarehouseSystemAnalyst.Data.Models.Dtos.ProductDtos;

namespace WarehouseSystemAnalyst.Configurations.MappingProfiles.ProductConfigs
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
            CreateMap<Pallet, PalletDto>().ReverseMap();
        }
    }
}