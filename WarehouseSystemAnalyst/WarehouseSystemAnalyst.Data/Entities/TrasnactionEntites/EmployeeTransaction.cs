using WarehouseSystemAnalyst.Data.Entites.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;
using WarehouseSystemAnalyst.Data.Entities.ContactEntities;

namespace WarehouseSystemAnalyst.Data.Entites.TrasnactionEntites
{
    public class EmployeeTransaction : BaseTransaction
    {
        public string EmployeeID { get; set; }
        public string MovementID { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Movement Movement { get; set; }
    }
}
