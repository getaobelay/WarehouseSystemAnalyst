using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Shared.Dtos.ProductDtos;
using WarehouseSystemAnalyst.Shared.Dtos.WarehouseDtos;

namespace WarehouseSystemAnalyst.Shared.Dtos.InventoryDtos
{
    public class StockDto : IBaseStockDto, IMapFrom<Stock>
    {
        public string PK { get; set; }
        public string Name { get; set; }
        public bool IsQuanityAvailable { get; set; }
        public decimal ProductQuantity { get; set; }
        public decimal BatchQuantity { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
        public IEnumerable<BatchDto> Batches { get; set; }
        public IEnumerable<AllocationWarehouseDto> AllocationWarehouses { get; set; }
        public IEnumerable<ShippingWarehouseDto> ShippingWarehouses { get; set; }

    }
}