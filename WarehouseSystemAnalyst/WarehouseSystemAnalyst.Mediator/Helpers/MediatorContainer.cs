using arehouseSystemAnalyst.Data.Interfaces.Repositories;
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
using WarehouseSystemAnalyst.Mediator.Dtos.InventoryDtos;
using WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos;
using WarehouseSystemAnalyst.Mediator.Dtos.WarehouseDtos;
using WarehouseSystemAnalyst.Mediator.Extensions;

namespace WarehouseSystemAnalyst.Mediator.Helpers
{
    public static class MediatorContainer
    {
        public static IMediator BuildMediator()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            builder.RegisterHandlers<Product, ProductDto>();
            builder.RegisterHandlers<ProductItem, ProductItemDto>();
            builder.RegisterHandlers<Stock, StockDto>();
            builder.RegisterHandlers<Inventory, InventoryDto>();
            builder.RegisterHandlers<Stock, InventoryDto>();
            builder.RegisterHandlers<ShippingWarehouse, ShippingWarehouseDto>();
            builder.RegisterHandlers<GoodsWarehouse, GoodsWarehouseDto>();
            builder.RegisterHandlers<AllocationWarehouse, AllocationWarehouseDto>();

            builder.RegisterGeneric(typeof(WarehouseRepository<>)).As(typeof(IWarehouseRepository<>));
            builder.RegisterGeneric(typeof(StockRepository<>)).As(typeof(IStockRepository<>));
            builder.RegisterGeneric(typeof(DataRepository<>)).As(typeof(IBaseRepository<>));
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