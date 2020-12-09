using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;

namespace WarehouseSystemAnalyst.Data.Entities.WarehouseEntites.WarehouseTypes
{
    public class AllocationWarehouse : IBaseWarehouse
    {
        public int Id { get; set; }
        public string PK { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string WarehouseName { get; set; }
        public string WarehouseItemID { get; set; }
        public string LocationID { get; set; }
        public string ProductID { get; set; }
        public string BatchID { get; set; }

        public ICollection<WarehouseItem> WarehouseItems { get; set; }
        public ICollection<Location> Locations { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Batch> Batches { get; set; }

    }
}


