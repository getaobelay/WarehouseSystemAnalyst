using AutoMapper;
using WarehouseSystemAnalyst.Data.Models.Data.InventoryModels;
using WarehouseSystemAnalyst.Data.Models.Dtos.InventoryDtos;

namespace WarehouseSystemAnalyst.Mediator.MappingProfiles.InventoryConfigs
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<StockDto, StockOut>().ReverseMap();
            CreateMap<StockOut, StockDto>();
        }
    }
}