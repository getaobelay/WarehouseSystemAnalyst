using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

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
        public ICollection<ProductMesures> ProductMesures { get; set; } = new HashSet<ProductMesures>();
        public ICollection<ProductItem> ProductItems { get; set; } = new HashSet<ProductItem>();

    }
}