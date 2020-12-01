using AutoMapper;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Models.Dtos.ProductDtos;

namespace WarehouseSystemAnalyst.Mediator.MappingProfiles.ProductConfigs
{
    public class ProductPackageProfile : Profile
    {
        public ProductPackageProfile()
        {
            {
                CreateMap<ProductPackages, ProductPackagesDto>()
                .ForMember(c => c.PackageType, opt => opt.MapFrom(src => src.Package.Type))
                .ForMember(c => c.Quantity, opt => opt.MapFrom(src => src.Product.Id));
            }
        }
    }
}