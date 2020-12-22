using AutoMapper;
using WarehouseSystemAnalyst.Data.Entities.ContactEntities;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites.WarehouseTypes;
using WarehouseSystemAnalyst.Shared.Dtos.ContactDtos;
using WarehouseSystemAnalyst.Shared.Dtos.WarehouseDtos;

namespace WarehouseSystemAnalyst.Shared.Dtos.MappingProfiles
{
    public class WarehouseProfiles : Profile
    {
        public WarehouseProfiles()
        {
            CreateMap<Allocation, AllocationDto>().ReverseMap();
            CreateMap<AllocationWarehouse, AllocationWarehouseDto>().ReverseMap();
            CreateMap<GoodsWarehouse, GoodsWarehouseDto>().ReverseMap();
            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<ShippingWarehouse, ShippingWarehouseDto>().ReverseMap();
            CreateMap<WarehouseItem, WarehouseItemDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}