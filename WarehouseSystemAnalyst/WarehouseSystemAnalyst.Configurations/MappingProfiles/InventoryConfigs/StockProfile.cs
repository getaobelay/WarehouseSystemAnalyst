using AutoMapper;
using WarehouseSystemAnalyst.Data.Models.Data.InventoryModels;
using WarehouseSystemAnalyst.Data.Models.Dtos.InventoryDtos;

namespace WarehouseSystemAnalyst.Configurations.MappingProfiles.InventoryConfigs
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