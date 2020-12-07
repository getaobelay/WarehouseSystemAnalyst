﻿using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Requests;

namespace WarehouseSystemAnalyst.Mediator.Common.Commands.Requests
{
    /// <summary>
    /// this command creates source and destination entities
    /// </summary>
    /// <typeparam name="TEntity">The entity to insert into the database</typeparam>
    /// <typeparam name="TDto">The source dto to map result from</typeparam>
    public class UpdateCommand<TEntity, TDto> : IUpdateRequest<TEntity, TDto>
      where TEntity : class, IBaseEntity, new()
      where TDto : class, IBaseDto, new()
    {
        public object Id { get; set; }
        public TEntity Entity { get; set; }
    }
}