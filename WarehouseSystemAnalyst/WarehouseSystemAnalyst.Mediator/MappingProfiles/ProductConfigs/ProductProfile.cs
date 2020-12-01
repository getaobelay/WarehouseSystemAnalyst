using AutoMapper;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Models.Dtos.ProductDtos;

namespace WarehouseSystemAnalyst.Mediator.MappingProfiles.ProductConfigs
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>();

            CreateMap<Product, ProductDto>()
                .ForMember(c => c.BatchPallet, opt => opt.MapFrom(src => src.Batches))
                .ForMember(c => c.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(c => c.SubCategory, opt => opt.MapFrom(src => src.SubCategory))
                .ForMember(c => c.StockQuantity, opt => opt.MapFrom(src => src.StockOut.UnitsInStock));
        }
    }
}