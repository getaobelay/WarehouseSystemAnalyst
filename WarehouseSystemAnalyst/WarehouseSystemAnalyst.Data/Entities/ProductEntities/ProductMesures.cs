using System;
using System.Collections.Generic;
using System.Text;
using WarehouseSystemAnalyst.Data.Entites.BaseEntites;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Entites.ProductEntities
{
    public class ProductMesures : BaseEntity
    {
        public decimal UnitBuyPrice { get; set; }
        public decimal UnitSellPrice { get; set; }
        public decimal QuantityPerUnit { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public string ProductID { get; set; }
        public string MesureID { get; set; }
        public Product Product { get; set; }
        public Mesure Mesure { get; set; }
    }
}
