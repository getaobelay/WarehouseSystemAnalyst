using AutoMapper;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Models.Dtos.ProductDtos;

namespace WarehouseSystemAnalyst.Mediator.MappingProfiles.ProductConfigs
{
    public class BatchProfile : Profile
    {
        public BatchProfile()
        {
            CreateMap<Batch, BatchDto>().ReverseMap();
            CreateMap<Batch, BatchDto>()
                       .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                       .ForMember(dest => dest.StockQuantity, opt => opt.MapFrom(src => src.Stock.UnitsInStock));
        }
    }
}