﻿using Autofac;
using MediatR;
using WarehouseSystemAnalyst.Data.Helpers;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Commands.StockCommands.Handlers;
using WarehouseSystemAnalyst.Mediator.Commands.StockCommands.Requests;
using WarehouseSystemAnalyst.Mediator.Common.Commands.Handlers;
using WarehouseSystemAnalyst.Mediator.Common.Commands.Requests;
using WarehouseSystemAnalyst.Mediator.Common.Queries.Handlers;
using WarehouseSystemAnalyst.Mediator.Common.Queries.Requests;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Requests;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Responses;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Requests;

namespace WarehouseSystemAnalyst.Mediator.Extensions
{
    public static class RegisterGenericHandlers
    {
        public static ContainerBuilder RegisterHandlers<TEntity, TDto>(this ContainerBuilder builder)
            where TEntity : class, IBaseEntity, new()
            where TDto : class, IBaseDto, new()

        {
            builder.RegisterType<CreateCommandHandler<TEntity, TDto, CreateCommandRequest<TEntity, TDto>>>()
                   .As<IRequestHandler<CreateCommandRequest<TEntity, TDto>, CommandResponse<TDto>>>();

            builder.RegisterType<DeleteCommandHandler<TEntity, TDto, DeleteCommandRequest<TEntity, TDto>>>()
                   .As<IRequestHandler<DeleteCommandRequest<TEntity, TDto>, CommandResponse<TDto>>>();

            builder.RegisterType<UpdateCommandHandler<TEntity, TDto, UpdateCommandRequest<TEntity, TDto>>>()
                   .As<IRequestHandler<UpdateCommandRequest<TEntity, TDto>, CommandResponse<TDto>>>();

            builder.RegisterType<SingleQueryHandler<TEntity, TDto, SingleQueryRequest<TEntity, TDto>>>()
                   .As<IRequestHandler<SingleQueryRequest<TEntity, TDto>, SingleQueryResponse<TDto>>>();

            builder.RegisterType<ListQueryHandler<TEntity, TDto, ListQueryRequest<TEntity, TDto>>>()
                   .As<IRequestHandler<ListQueryRequest<TEntity, TDto>, ListQueryResponse<TDto>>>();

            return builder;
        }

        public static ContainerBuilder RegisterInventoryHandlers<TSourceEntity, TSourceDto, TDestEntity, TDestDto>(this ContainerBuilder builder)
            where TSourceEntity : class, IBaseStock, new()
            where TSourceDto : class, IBaseStockDto, new()
            where TDestEntity : class, IBaseStock, new()
            where TDestDto : class, IBaseStockDto, new()

        {
            builder.RegisterType<CreateInventoryCommandHandler<TSourceEntity, TSourceDto, TDestEntity, TDestDto, CreateInventoryCommand<TSourceEntity, TSourceDto, TDestEntity, TDestDto>>>()
                .As<IRequestHandler<CreateInventoryCommand<TSourceEntity, TSourceDto, TDestEntity, TDestDto>, TransactionResponse<TSourceDto, TDestDto>>>();

            builder.RegisterType<UpdateInventoryCommandHandler<TSourceEntity, TSourceDto, TDestEntity, TDestDto, UpdateInventoryCommand<TSourceEntity, TSourceDto, TDestEntity, TDestDto>>>()
               .As<IRequestHandler<UpdateInventoryCommand<TSourceEntity, TSourceDto, TDestEntity, TDestDto>, TransactionResponse<TSourceDto, TDestDto>>>();

            return builder;
        }

        public static ContainerBuilder RegisterWarehouseHandlers<TSourceEntity, TSourceDto, TDestEntity, TDestDto>(this ContainerBuilder builder)
         where TSourceEntity : class, IBaseWarehouse, new()
         where TSourceDto : class, IBaseWarehouseDto, new()
         where TDestEntity : class, IBaseWarehouse, new()
         where TDestDto : class, IBaseWarehouseDto, new()

        {
            return builder;
        }

    }
}