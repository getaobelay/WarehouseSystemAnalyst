using Autofac;
using MediatR;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Handlers;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Requests;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Responses;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Queries.Handlers;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Queries.Requests;
using WarehouseSystemAnalyst.Mediator.Helpers;
using WarehouseSystemAnalyst.Shared.Dtos.BaseDtos;

namespace WarehouseSystemAnalyst.Mediator.loC
{
    public static class RegisterGenericHandlersHelper
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
                   .As<IRequestHandler<SingleQueryRequest<TEntity, TDto>, HandlerResponse<TDto>>>();

            builder.RegisterType<ListQueryHandler<TEntity, TDto, ListQueryRequest<TEntity, TDto>>>()
                   .As<IRequestHandler<ListQueryRequest<TEntity, TDto>, HandlerResponse<TDto>>>();

            builder.RegisterAllProccessors<TEntity, TDto>();

            return builder;
        }

    }
}