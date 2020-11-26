using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entites.TrasnactionEntites;

namespace WarehouseSystemAnalyst.Data.Models.Dtos.WarehouseDtos
{
    public class WarehouseDto
    {

        public string WarehouseID { get; set; }
        public string WarehouseName { get; set; }
        public IEnumerable<MovementDto> Movements { get; set; }
        public IEnumerable<LocationDto> Locations { get; set; }
        public IEnumerable<WarehouseTransaction> Transactions { get; set; }
    }
}