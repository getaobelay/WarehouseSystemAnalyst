using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseSystemAnalyst.Data.Entites.ProductEntities;

namespace WarehouseSystemAnalyst.Data.Entites.InventoryEntites
{
    public class Supplier
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierPK { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual ICollection<ProductSuppliers> ProductSuppliers { get; set; }

        public Supplier()
        {
            ProductSuppliers = new HashSet<ProductSuppliers>();
        }
    }
}