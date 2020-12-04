using Autofac;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Reflection;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites.WarehouseTypes;
using WarehouseSystemAnalyst.Data.Implementation.Repositories;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;
using WarehouseSystemAnalyst.Data.Models.Dtos.InventoryDtos;
using WarehouseSystemAnalyst.Data.Models.Dtos.ProductDtos;
using WarehouseSystemAnalyst.Mediator.Behaviours;
using WarehouseSystemAnalyst.Mediator.Extensions;

namespace WarehouseSystemAnalyst.Mediator.Containers
{
    public static class MediatorContainer
    {
        public static IMediator BuildMediator()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterGenericHandlers<Product, ProductDto>();
            builder.RegisterGenericHandlers<Stock, StockDto>();
            builder.RegisterGenericHandlers<Inventory, InventoryDto>();
            builder.RegisterGenericHandlers<Stock, InventoryDto>();
            builder.RegisterGenericHandlers<ShippingWarehouse, ShippingWarehouse>();
            builder.RegisterGenericHandlers<GoodsWarehouse, GoodsWarehouse>();
            builder.RegisterGenericHandlers<AllocationWarehouse, AllocationWarehouse>();

            builder.RegisterGenericInventoryHandlers<Stock, StockDto, Inventory, InventoryDto >();
            builder.RegisterGenericInventoryHandlers<Inventory, InventoryDto, Stock, StockDto>();
            builder.RegisterGenericWarehouseHandlers<GoodsWarehouse, GoodsWarehouse, AllocationWarehouse, AllocationWarehouse>();
            builder.RegisterGenericWarehouseHandlers<AllocationWarehouse, AllocationWarehouse, GoodsWarehouse, GoodsWarehouse>();
            builder.RegisterGenericWarehouseHandlers<ShippingWarehouse, ShippingWarehouse, AllocationWarehouse, AllocationWarehouse>();
            builder.RegisterGenericWarehouseHandlers<AllocationWarehouse, AllocationWarehouse, ShippingWarehouse, ShippingWarehouse>();

            builder.RegisterGeneric(typeof(CommandBehaviour<,,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(UnitOfWorkRepository<>)).As(typeof(IUnitOfWorkRepository<>));
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