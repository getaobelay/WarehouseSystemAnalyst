using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;

namespace WarehouseSystemAnalyst.Data.Entities.BaseEntites
{
    public interface IBaseStock : IBaseEntity
    {

        public string Name { get; set; }
        public bool IsQuanityAvailable { get; set; }
        public decimal TotalUnitsQuantity { get; set; }
        public decimal ProductQuantity { get; set; }
        public decimal BatchQuantity { get; set; }
        public string ProductId { get; set; }
        public string BatchId { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<Batch> Batches { get; set; }
    }
}