using AutoMapper;
using WarehouseSystemAnalyst.Data.Models.Data.InventoryModels;
using WarehouseSystemAnalyst.Data.Models.Dtos.InventoryDtos;

namespace WarehouseSystemAnalyst.Mediator.MappingProfiles.InventoryConfigs
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<InventoryDto, StockIn>();

            CreateMap<StockIn, InventoryDto>();
        }
    }
}