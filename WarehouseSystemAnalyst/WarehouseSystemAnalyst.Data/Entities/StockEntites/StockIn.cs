using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;

namespace WarehouseSystemAnalyst.Data.Entities.StockEntites
{
    public class StockIn : BaseStock
    {
        public decimal UnitsInStock { get; set; }
        public decimal ReorderLevel { get; set; }
    }
}