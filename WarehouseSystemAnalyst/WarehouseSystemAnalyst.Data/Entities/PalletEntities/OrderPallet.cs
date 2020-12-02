using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.SupplyChainEntities;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Entities.PalletEntities
{
    public class OrderPallet : IBasePallet
    {
        public int Id { get; set; }
        public string PK { get; set; }
        public string SupplierPallet { get; set; }
        public string PalletNumber { get; set; }
        public string PalletCode { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string OrderId { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}