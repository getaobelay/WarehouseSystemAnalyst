using WarehouseSystemAnalyst.Data.Models.Dtos.WarehouseDtos;

namespace WarehouseSystemAnalyst.Data.Models.Dtos.TransactionModels
{
    public class WarehouseMovementDto
    {
        public string WarehouseID { get; set; }
        public string MovementID { get; set; }

        public WarehouseDto Warehouse { get; set; }
        public MovementDto Movement { get; set; }
    }
}
