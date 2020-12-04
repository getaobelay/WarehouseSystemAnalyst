using Autofac;
using MediatR;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Commands.Handlers.CreateCommands;
using WarehouseSystemAnalyst.Mediator.Commands.Handlers.DeleteCommands;
using WarehouseSystemAnalyst.Mediator.Commands.Handlers.UpdateCommands;
using WarehouseSystemAnalyst.Mediator.Commands.Requests.CreateCommands;
using WarehouseSystemAnalyst.Mediator.Commands.Requests;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;
using WarehouseSystemAnalyst.Mediator.Queries.Handlers;
using WarehouseSystemAnalyst.Mediator.Queries.Requests;

namespace WarehouseSystemAnalyst.Mediator.Extensions
{
    public static class RegisterMediatorGenericHandlers
    {
        public static ContainerBuilder RegisterGenericHandlers<TEntity, TDto>(this ContainerBuilder builder)
            where TEntity : class, IBaseEntity, new()
            where TDto : class, new()

        {
            builder.RegisterType<CreateCommandHandler<TEntity, CreateCommand<TEntity, TDto>>>()
                   .As<IRequestHandler<CreateCommand<TEntity, TDto>, ICommandResponse<TEntity>>>();

            builder.RegisterType<DeleteCommandHandler<TEntity, DeleteCommand<TEntity, TDto>>>()
                   .As<IRequestHandler<DeleteCommand<TEntity, TDto>, ICommandResponse<TEntity>>>();

            builder.RegisterType<UpdateCommandHandler<TEntity, UpdateCommand<TEntity, TDto>>>()
                   .As<IRequestHandler<UpdateCommand<TEntity, TDto>, ICommandResponse<TEntity>>>();

            builder.RegisterType<SingleQueryHandler<TEntity, TDto, SingleQuery<TEntity, TDto>>>()
                   .As<IRequestHandler<SingleQuery<TEntity, TDto>, IQueryResponse<TEntity>>>();

            builder.RegisterType<ListQueryHandler<TEntity, TDto, ListQuery<TEntity, TDto>>>()
                   .As<IRequestHandler<ListQuery<TEntity, TDto>, IQueryResponse<TEntity>>>();

            return builder;
        }
        public static ContainerBuilder RegisterGenericInventoryHandlers<TSource, TSourceDto, TDestension, TDestensionDto>(this ContainerBuilder builder)
            where TSource : class, IBaseStock, new()
            where TDestension : class, IBaseStock, new()
            where TSourceDto : class, new()
            where TDestensionDto : class, new()

        {
            builder.RegisterType<CreateInventoryCommandHandler<TSource, TSourceDto, TDestension, TDestensionDto,
                  CreateTransactionCommand<TSource, TSourceDto, TDestension, TDestensionDto>>>()
                 .As<IRequestHandler<CreateTransactionCommand<TSource, TSourceDto, TDestension, TDestensionDto>, ITransactionCommandResponse<TSourceDto, TDestensionDto>>>();

            builder.RegisterType<DeleteInventoryCommandHandler<TSource, TSourceDto, TDestension, TDestensionDto,
               DeleteTransactionCommand<TSource, TSourceDto, TDestension, TDestensionDto>>>()
              .As<IRequestHandler<DeleteTransactionCommand<TSource, TSourceDto, TDestension, TDestensionDto>,
              ITransactionCommandResponse<TSourceDto, TDestensionDto>>>();

            builder.RegisterType<UpdateInventoryCommandHandler<TSource, TSourceDto, TDestension, TDestensionDto,
               UpdateTransactionCommand<TSource, TSourceDto, TDestension, TDestensionDto>>>()
              .As<IRequestHandler<UpdateTransactionCommand<TSource, TSourceDto, TDestension, TDestensionDto>,
              ITransactionCommandResponse<TSourceDto, TDestensionDto>>>();

            return builder;
        }
        public static ContainerBuilder RegisterGenericWarehouseHandlers<TSource, TSourceDto, TDestension, TDestensionDto>(this ContainerBuilder builder)
            where TSource : class, IBaseWarehouse, new()
            where TDestension : class, IBaseWarehouse, new()
            where TSourceDto : class, new()
            where TDestensionDto : class, new()
        {
            builder.RegisterType<CreateWarehouseCommandHandler<TSource,TSourceDto, TDestension, TDestensionDto,
                 CreateTransactionCommand<TSource, TSourceDto, TDestension, TDestensionDto>>>()
                .As<IRequestHandler<CreateTransactionCommand<TSource, TSourceDto, TDestension, TDestensionDto >,ITransactionCommandResponse<TSourceDto, TDestensionDto>>>();

            builder.RegisterType<DeleteWarehouseCommandHandler<TSource, TSourceDto, TDestension, TDestensionDto,
               DeleteTransactionCommand<TSource, TSourceDto, TDestension, TDestensionDto>>>()
              .As<IRequestHandler<DeleteTransactionCommand<TSource, TSourceDto, TDestension, TDestensionDto>,
              ITransactionCommandResponse<TSourceDto, TDestensionDto>>>();

            builder.RegisterType<UpdateWarehouseCommandHandler<TSource, TSourceDto, TDestension, TDestensionDto,
               UpdateTransactionCommand<TSource, TSourceDto, TDestension, TDestensionDto>>>()
              .As<IRequestHandler<UpdateTransactionCommand<TSource, TSourceDto, TDestension, TDestensionDto>,
              ITransactionCommandResponse<TSourceDto, TDestensionDto>>>();

            return builder;
        }
    }
}