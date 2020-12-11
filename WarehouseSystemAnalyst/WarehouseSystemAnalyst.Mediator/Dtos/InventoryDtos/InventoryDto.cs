using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos;
using WarehouseSystemAnalyst.Mediator.Dtos.WarehouseDtos;
using WarehouseSystemAnalyst.Mediator.Helpers;

namespace WarehouseSystemAnalyst.Mediator.Dtos.InventoryDtos
{
    public class InventoryDto : IBaseStockDto, IMapFrom<Inventory>
    {
        public string PK { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsQuanityAvailable { get; set; }
        public decimal TotalUnitsQuantity { get; set; }
        public decimal ProductQuantity { get; set; }
        public decimal BatchQuantity { get; set; }
        public decimal UnitsInInventory { get; set; }
        public decimal UnitsInOrder { get; set; }
        public decimal ReorderLevel { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
        public IEnumerable<BatchDto> Batches { get; set; }
        public IEnumerable<AllocationWarehouseDto> AllocationWarehouses { get; set; }
        public IEnumerable<GoodsWarehouseDto> GoodsWarehouses { get; set; }
    }
}