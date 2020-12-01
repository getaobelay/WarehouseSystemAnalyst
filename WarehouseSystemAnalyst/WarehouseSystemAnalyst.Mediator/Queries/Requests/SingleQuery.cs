﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WarehouseSystemAnalyst.Interfaces.CQRS.Models;
using WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers;

namespace WarehouseSystemAnalyst.Mediator.Queries.Requests
{
    public class SingleQuery<TEntity, TDto, TContext> : IQueryWrapper<TEntity>
        where TEntity : class, new()
        where TDto : class, new()
        where TContext : DbContext, new()
    {
        public IWarehouseContext<TContext, TEntity> Context { get; set; }
        public Expression<Func<TEntity, bool>> Expression { get; set; }
        public IEnumerable<TEntity> Models { get; set; }
        public TEntity Model { get; set; }
    }
}