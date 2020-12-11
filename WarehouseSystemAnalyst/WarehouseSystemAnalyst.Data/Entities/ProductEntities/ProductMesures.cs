using System;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;

namespace WarehouseSystemAnalyst.Data.Entities.ProductEntities
{
    public class ProductMesures : IBaseEntity
    {
        public int Id { get; set; }
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public decimal UnitBuyPrice { get; set; }
        public decimal UnitSellPrice { get; set; }
        public decimal QuantityPerUnit { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public string ProductId { get; set; }
        public string MesureId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Mesure Mesure { get; set; }
    }
}