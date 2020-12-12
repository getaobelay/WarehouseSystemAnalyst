﻿using Autofac;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Reflection;
using WarehouseSystemAnalyst.Data.Context;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites.WarehouseTypes;
using WarehouseSystemAnalyst.Data.Implementation;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;
using WarehouseSystemAnalyst.Mediator.Commands.Behaviours.CommonBehaviours;
using WarehouseSystemAnalyst.Mediator.Dtos.InventoryDtos;
using WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos;
using WarehouseSystemAnalyst.Mediator.Dtos.WarehouseDtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.loC
{

    public static class MediatorContainer
    {

        public static IMediator BuildMediator()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            builder.RegisterHandlers<GoodsWarehouse, GoodsWarehouseDto>();
            builder.RegisterHandlers<AllocationWarehouse, AllocationWarehouseDto>();
            builder.RegisterHandlers<ShippingWarehouse, ShippingWarehouseDto>();
            builder.RegisterHandlers<Product, ProductDto>();
            builder.RegisterHandlers<ProductItem, ProductItemDto>();
            builder.RegisterHandlers<Stock, StockDto>();
            builder.RegisterHandlers<Inventory, InventoryDto>();

            builder.RegisterType(typeof(DataContext)).As(typeof(IDataContext));
            builder.RegisterGeneric(typeof(UnitOfWorkRepository<>)).As(typeof(IUnitOfWorkRepository<>));

            builder.RegisterType<LoggerFactory>()
               .As<ILoggerFactory>()
               .SingleInstance();

            builder.RegisterGeneric(typeof(Logger<>))
                .As(typeof(ILogger<>))
                .SingleInstance();

            builder.Register<ServiceFactory>(ctx =>

            {
                var c = ctx.Resolve<IComponentContext>();

                return t => c.Resolve(t);
            });

            var container = builder.Build();

            return container.ResolveOptional<IMediator>();
        }
    }
}