using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.ContactEntities;
using WarehouseSystemAnalyst.Mediator.Dtos.WarehouseDtos;
using WarehouseSystemAnalyst.Mediator.Mapping;

namespace WarehouseSystemAnalyst.Mediator.Dtos.ContactDtos
{
    public class EmployeeDto : BaseDto, IMapFrom<Employee>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string WarehouseItemId { get; set; }
        public IEnumerable<WarehouseItemDto> WarehouseItems { get; set; }
    }
}