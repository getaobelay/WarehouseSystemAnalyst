using AutoMapper;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Models.Dtos.ProductDtos;

namespace WarehouseSystemAnalyst.Mediator.MappingProfiles.ProductConfigs
{
    public class ProductMesureProfile : Profile
    {
        public ProductMesureProfile()
        {
            CreateMap<ProductMesures, ProductMesuresDto>()
            .ForMember(c => c.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
            .ForMember(c => c.Quantity, opt => opt.MapFrom(src => src.Product.Id));
        }
    }
}