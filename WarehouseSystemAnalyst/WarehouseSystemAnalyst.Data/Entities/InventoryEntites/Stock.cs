﻿using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;

namespace WarehouseSystemAnalyst.Data.Models.Data.InventoryModels
{
    public class Stock : BaseInventory
    {
        public decimal UnitsInStock { get; set; }
        public decimal ReorderLevel { get; set; }
    }
}