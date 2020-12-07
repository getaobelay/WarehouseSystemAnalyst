﻿using System.Collections.Generic;
using WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos;
using WarehouseSystemAnalyst.Mediator.Dtos.WarehouseDtos;

namespace WarehouseSystemAnalyst.Mediator.Dtos
{
    public class BaseStockDto : BaseDto
    {
        public string Name { get; set; }
        public bool IsQuanityAvailable { get; set; }
        public decimal TotalUnitsQuantity { get; set; }
        public decimal ProductQuantity { get; set; }
        public decimal BatchQuantity { get; set; }
        public decimal UnitsInOrder { get; set; }
        public decimal ReorderLevel { get; set; }

        public IEnumerable<ProductDto> Products { get; set; }
        public IEnumerable<BatchDto> Batches { get; set; }
        public IEnumerable<AllocationWarehouseDto> AllocationWarehouses { get; set; }
    }
}