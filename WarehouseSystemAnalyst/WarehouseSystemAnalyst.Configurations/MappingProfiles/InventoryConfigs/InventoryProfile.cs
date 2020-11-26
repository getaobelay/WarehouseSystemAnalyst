using AutoMapper;
using WarehouseSystemAnalyst.Data.Models.Data.InventoryModels;
using WarehouseSystemAnalyst.Data.Models.Dtos.InventoryDtos;

namespace WarehouseSystemAnalyst.Configurations.MappingProfiles.InventoryConfigs
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<InventoryDto, Inventory>();

            CreateMap<Inventory, InventoryDto>();
        }
    }
}