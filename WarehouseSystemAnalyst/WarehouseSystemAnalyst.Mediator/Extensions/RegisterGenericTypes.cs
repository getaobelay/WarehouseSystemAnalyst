using Autofac;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WarehouseSystemAnalyst.Mediator.Commands.Handlers;
using WarehouseSystemAnalyst.Mediator.Commands.Requests;
using WarehouseSystemAnalyst.Mediator.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Queries.Handlers;
using WarehouseSystemAnalyst.Mediator.Queries.Requests;

namespace WarehouseSystemAnalyst.Mediator.Extensions
{
    public static class RegisterGenericTypes
    {
        public static ContainerBuilder RegisterCrudType<TEntity, TDto, TContext>(this ContainerBuilder builder)
            where TEntity : class, new()
            where TDto : class, new()
            where TContext : DbContext, new()

        {
            builder.RegisterType<CreateCommandHandler<TEntity, CreateCommand<TEntity, TDto, TContext>, TContext>>()
                   .As<IRequestHandler<CreateCommand<TEntity, TDto, TContext>, ICommandResponse<TEntity>>>();

            builder.RegisterType<DeleteCommandHandler<TEntity, DeleteCommand<TEntity, TDto, TContext>, TContext>>()
                   .As<IRequestHandler<DeleteCommand<TEntity, TDto, TContext>, ICommandResponse<TEntity>>>();

            builder.RegisterType<UpdateCommandHandler<TEntity, UpdateCommand<TEntity, TDto, TContext>, TContext>>()
                   .As<IRequestHandler<UpdateCommand<TEntity, TDto, TContext>, ICommandResponse<TEntity>>>();

            builder.RegisterType<SingleQueryHandler<TEntity, TDto, SingleQuery<TEntity, TDto, TContext>, TContext>>()
                   .As<IRequestHandler<SingleQuery<TEntity, TDto, TContext>, IQueryResponse<TEntity>>>();

            builder.RegisterType<ListQueryHandler<TEntity, TDto, ListQuery<TEntity, TDto, TContext>, TContext>>()
                   .As<IRequestHandler<ListQuery<TEntity, TDto, TContext>, IQueryResponse<TEntity>>>();

            return builder;
        }

        public static ContainerBuilder RegisterInventoryType<TSource, TDestension>(this ContainerBuilder builder)
            where TSource : class, new()
            where TDestension : class, new()
        {
            //builder.RegisterType<MoveQuantityCommandHandler<TSource, TDestension, MoveQuantityCommand<TSource, TDestension>>>()
            //   .As<IRequestHandler<MoveQuantityCommand<TSource, TDestension>, bool>>();
            return builder;
        }

        public static ContainerBuilder RegisterInventoryHandlers<TEntity>(this ContainerBuilder builder)
           where TEntity : class, new()
        {
            return builder;
        }
    }
}