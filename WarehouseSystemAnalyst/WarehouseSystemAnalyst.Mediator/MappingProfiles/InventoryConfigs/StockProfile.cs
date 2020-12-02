using AutoMapper;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Data.Models.Dtos.InventoryDtos;

namespace WarehouseSystemAnalyst.Mediator.MappingProfiles.InventoryConfigs
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<StockDto, Stock>().ReverseMap();
            CreateMap<Stock, StockDto>();
        }
    }
}