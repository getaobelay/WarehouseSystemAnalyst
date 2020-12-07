using Autofac;
using MediatR;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Commands.Handlers.CreateCommands;
using WarehouseSystemAnalyst.Mediator.Commands.Handlers.DeleteCommands;
using WarehouseSystemAnalyst.Mediator.Commands.Handlers.UpdateCommands;
using WarehouseSystemAnalyst.Mediator.Commands.Requests;
using WarehouseSystemAnalyst.Mediator.Commands.Requests.CreateCommands;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;
using WarehouseSystemAnalyst.Mediator.Queries.Handlers;
using WarehouseSystemAnalyst.Mediator.Queries.Requests;

namespace WarehouseSystemAnalyst.Mediator.Extensions
{
    public static class RegisterGenericHandlers
    {
        public static ContainerBuilder RegisterHandlers<TEntity, TDto>(this ContainerBuilder builder)
            where TEntity : class, IBaseEntity, new()
            where TDto : BaseDto, new()

        {
            builder.RegisterType<CreateCommandHandler<TEntity, TDto, CreateCommand<TEntity, TDto>>>()
                   .As<IRequestHandler<CreateCommand<TEntity, TDto>, ICommandResponse<TDto>>>();

            builder.RegisterType<DeleteCommandHandler<TEntity, TDto, DeleteCommand<TEntity, TDto>>>()
                   .As<IRequestHandler<DeleteCommand<TEntity, TDto>, ICommandResponse<TDto>>>();

            builder.RegisterType<UpdateCommandHandler<TEntity, TDto, UpdateCommand<TEntity, TDto>>>()
                   .As<IRequestHandler<UpdateCommand<TEntity, TDto>, ICommandResponse<TDto>>>();

            builder.RegisterType<SingleQueryHandler<TEntity, TDto, SingleQuery<TEntity, TDto>>>()
                   .As<IRequestHandler<SingleQuery<TEntity, TDto>, IQueryResponse<TDto>>>();

            builder.RegisterType<ListQueryHandler<TEntity, TDto, ListQuery<TEntity, TDto>>>()
                   .As<IRequestHandler<ListQuery<TEntity, TDto>, IListQueryResponse<TDto>>>();

            return builder;
        }
    }
}