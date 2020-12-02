using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Entities.ProductEntities
{
    public class ProductItem : IBaseEntity
    {
        public int Id { get; set; }
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ProductName { get; set; }
        public decimal BuyPricePerUnit { get; set; }
        public decimal SellPricePerUnit { get; set; }
        public string Metrial { get; set; }
        public string ProductId { get; set; }
        public string BatchId { get; set; }
        public string MesureId { get; set; }
        public string AllocationId { get; set; }

        public virtual ICollection<Batch> Batches { get; set; }
        public virtual Allocation Allocation { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public virtual ICollection<Mesure> UnitOfMesure { get; set; } = new HashSet<Mesure>();
    }
}