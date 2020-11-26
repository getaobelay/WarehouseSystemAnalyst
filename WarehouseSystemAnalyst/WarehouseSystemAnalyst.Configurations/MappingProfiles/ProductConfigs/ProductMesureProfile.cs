using AutoMapper;
using WarehouseSystemAnalyst.Data.Models.Data.ProductModels;
using WarehouseSystemAnalyst.Data.Models.Dtos.ProductDtos;

namespace WarehouseSystemAnalyst.Configurations.MappingProfiles.ProductConfigs
{
    public class ProductMesureProfile : Profile
    {
        public ProductMesureProfile()
        {
            CreateMap<ProductMesures, ProductMesuresDto>()
            .ForMember(c => c.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
            .ForMember(c => c.Quantity, opt => opt.MapFrom(src => src.Product.Quantity))
            .ForMember(c => c.Measurement, opt => opt.MapFrom(src => src.Mesure.Measurement));
        }
    }
}