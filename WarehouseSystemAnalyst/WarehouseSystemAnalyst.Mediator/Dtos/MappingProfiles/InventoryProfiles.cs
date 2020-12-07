using AutoMapper;
using WarehouseSystemAnalyst.Data.Entities.ContactEntities;
using WarehouseSystemAnalyst.Data.Entities.PalletEntities;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Data.Entities.SupplyChainEntities;
using WarehouseSystemAnalyst.Mediator.Dtos.ContactDtos;
using WarehouseSystemAnalyst.Mediator.Dtos.InventoryDtos;
using WarehouseSystemAnalyst.Mediator.Dtos.PalletDtos;
using WarehouseSystemAnalyst.Mediator.Dtos.SupplyChainEntities;

;

namespace WarehouseSystemAnalyst.Mediator.Dtos.MappingProfiles
{
    public class InventoryProfiles : Profile
    {
        public InventoryProfiles()
        {
            CreateMap<Inventory, InventoryDto>().ReverseMap();
            CreateMap<Stock, StockDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderPallet, OrderPalletDto>().ReverseMap();
            CreateMap<Vendor, VendorDto>().ReverseMap();
            CreateMap<ProductVendor, ProductVendorDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}