using AutoMapper;
using WarehouseSystemAnalyst.Data.Entities.ContactEntities;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Data.Entities.SupplyChainEntities;
using WarehouseSystemAnalyst.Shared.Dtos.ContactDtos;
using WarehouseSystemAnalyst.Shared.Dtos.InventoryDtos;
using WarehouseSystemAnalyst.Shared.Dtos.SupplyChainEntities;


namespace WarehouseSystemAnalyst.Shared.Dtos.MappingProfiles
{
    public class InventoryProfiles : Profile
    {
        public InventoryProfiles()
        {
            CreateMap<Inventory, InventoryDto>().ReverseMap();
            CreateMap<Stock, StockDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Vendor, VendorDto>().ReverseMap();
            CreateMap<ProductVendor, ProductVendorDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}