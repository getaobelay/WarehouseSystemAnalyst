using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Mediator.Helpers;

namespace WarehouseSystemAnalyst.Mediator.Dtos.WarehouseDtos
{
    public class LocationDto : IBaseDto, IMapFrom<Location>
    {
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string LocationRow { get; set; }
        public string LocationColum { get; set; }
        public string LocationShelf { get; set; }

        public ICollection<AllocationWarehouseDto> AllocationWarehouses { get; set; }
        public ICollection<GoodsWarehouseDto> GoodsWarehouses { get; set; }
        public ICollection<ShippingWarehouseDto> ShippingWarehouses { get; set; }
        public ICollection<WarehouseItemDto> WarehouseItems { get; set; }
    }
}