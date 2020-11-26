﻿using Autofac;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Reflection;
using WarehouseSystemAnalyst.Data.Context;
using WarehouseSystemAnalyst.Data.Models.Data.InventoryModels;
using WarehouseSystemAnalyst.Data.Models.Data.ProductModels;
using WarehouseSystemAnalyst.Data.Models.Data.WarehouseModels;
using WarehouseSystemAnalyst.Data.Models.Dtos.InventoryDtos;
using WarehouseSystemAnalyst.Data.Models.Dtos.ProductDtos;
using WarehouseSystemAnalyst.Data.Models.Dtos.WarehouseDtos;
using WarehouseSystemAnalyst.Mediator.Behaviours;
using WarehouseSystemAnalyst.Configurations.Extensions;

namespace WarehouseSystemAnalyst.Shared.Containers
{
    public static class MediatorContainer
    {
        public static IMediator BuildMediator()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterCrudType<Product, ProductDto, WarehouseDbContext>();
            builder.RegisterCrudType<Inventory, InventoryDto, WarehouseDbContext>();
            builder.RegisterCrudType<Stock, StockDto, WarehouseDbContext>();
            builder.RegisterCrudType<Inventory, InventoryDto, WarehouseDbContext>();
            builder.RegisterCrudType<Warehouse, WarehouseDto, WarehouseDbContext>();
            builder.RegisterCrudType<Movement, MovementDto, WarehouseDbContext>();

            builder.RegisterGeneric(typeof(CommandBehaviour<,,>)).As(typeof(IPipelineBehavior<,>));

            builder.RegisterType<WarehouseDbContext>();

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

            var mediator = container.ResolveOptional<IMediator>();

            return mediator;
        }
    }
}