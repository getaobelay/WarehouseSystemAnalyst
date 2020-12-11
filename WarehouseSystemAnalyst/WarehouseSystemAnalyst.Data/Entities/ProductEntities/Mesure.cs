using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;

namespace WarehouseSystemAnalyst.Data.Entities.ProductEntities
{
    public class Mesure : IBaseEntity
    {
        public int Id { get; set; }
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ProductMesureId { get; set; }
        public string ProductItemId { get; set; }
        public virtual ICollection<ProductMesures> ProductMesures { get; set; } = new HashSet<ProductMesures>();
        public virtual ICollection<ProductItem> ProductItems { get; set; } = new HashSet<ProductItem>();
    }
}