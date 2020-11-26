using WarehouseSystemAnalyst.Data.Entites.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Entites.UserEntites;

namespace WarehouseSystemAnalyst.Data.Models.Dtos.TransactionModels
{
    public class EmployeeMovementDto
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string ProductID { get; set; }
        public string ProductPallet { get; set; }
        public string ActionType { get; set; }
        public string CreationDate { get; set; }
        public string UpdateDate { get; set; }
        public string MovementID { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Movement Movement { get; set; }
    }
}
