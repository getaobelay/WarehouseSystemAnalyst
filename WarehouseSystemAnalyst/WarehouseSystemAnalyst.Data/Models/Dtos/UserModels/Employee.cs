using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Models.Dtos.TransactionModels;
using WarehouseSystemAnalyst.Data.Models.Dtos.WarehouseDtos;

namespace WarehouseSystemAnalyst.Data.Models.Dtos.UserModels
{
    public class EmployeeDto
    {
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<MovementDto> Movements { get; set; }
        public IEnumerable<EmployeeMovementDto> Transactions { get; set; }
    }
}