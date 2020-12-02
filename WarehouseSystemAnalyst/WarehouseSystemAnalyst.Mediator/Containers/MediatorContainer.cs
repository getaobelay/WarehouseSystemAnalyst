using Autofac;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Reflection;
using WarehouseSystemAnalyst.Data.Models.Dtos.InventoryDtos;
using WarehouseSystemAnalyst.Data.Models.Dtos.ProductDtos;
using WarehouseSystemAnalyst.Mediator.Behaviours;
using WarehouseSystemAnalyst.Mediator.Extensions;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;

namespace WarehouseSystemAnalyst.Mediator.Containers
{
    public static class MediatorContainer
    {
        public static IMediator BuildMediator()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterCrudType<Product, ProductDto, WarehouseDbContext>();
            builder.RegisterCrudType<Stock, InventoryDto, WarehouseDbContext>();
            builder.RegisterCrudType<Inventory, StockDto, WarehouseDbContext>();
            builder.RegisterCrudType<Stock, InventoryDto, WarehouseDbContext>();
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