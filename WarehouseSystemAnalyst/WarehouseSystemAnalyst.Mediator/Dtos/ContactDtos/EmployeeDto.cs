using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.ContactEntities;
using WarehouseSystemAnalyst.Mediator.Dtos.WarehouseDtos;
using WarehouseSystemAnalyst.Mediator.Helpers;

namespace WarehouseSystemAnalyst.Mediator.Dtos.ContactDtos
{
    public class EmployeeDto : IBaseDto, IMapFrom<Employee>
    {
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string WarehouseItemId { get; set; }
        public IEnumerable<WarehouseItemDto> WarehouseItems { get; set; }
    }
}