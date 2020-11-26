using System.Collections.Generic;

namespace WarehouseSystemAnalyst.Data.Models.Dtos.WarehouseDtos
{
    public class LocationDto
    {
        public string LocationID { get; set; }
        public string Location { get; set; }
        public WarehouseDto Warehouse { get; set; }
        public IEnumerable<MovementDto> Movements { get; set; }
    }
}