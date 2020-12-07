using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Mediator.Mapping;

namespace WarehouseSystemAnalyst.Mediator.Dtos.WarehouseDtos
{
    public class LocationDto : BaseDto, IMapFrom<Location>
    {
        public string LocationRow { get; set; }
        public string LocationColum { get; set; }
        public string LocationShelf { get; set; }

        public ICollection<AllocationWarehouseDto> AllocationWarehouses { get; set; }
        public ICollection<GoodsWarehouseDto> GoodsWarehouses { get; set; }
        public ICollection<ShippingWarehouseDto> ShippingWarehouses { get; set; }
        public ICollection<WarehouseItemDto> WarehouseItems { get; set; }
    }
}