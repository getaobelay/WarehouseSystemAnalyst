﻿using System.Collections;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Requests;
using WarehouseSystemAnalyst.Shared.Dtos.WarehouseDtos;
using WarehouseSystemAnalyst.Shared.Dtos.BaseDtos;

namespace WarehouseSystemAnalyst.Mediator.WarehouseCQRS.Requests
{
    public class UpdateWarehouseItemCommandRequest<TEntity, TDto> : BaseCommandRequest<TEntity, TDto>
   where TEntity : class, IBaseEntity, new()
  where TDto : class, IBaseDto, new()
    {
        public object AllocationId { get; set; }
        public object DestinationId { get; set; }
        WarehouseItemDto WarehouseItem { get; set; }
    }

}