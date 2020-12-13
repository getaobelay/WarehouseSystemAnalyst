using Autofac;
using MediatR;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Requests;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Responses;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Proccessors;

namespace WarehouseSystemAnalyst.Mediator.loC
{
    public static class RegisterCommandProccessorHelper
    {
        public static ContainerBuilder RegisterCommandProccessors<TEntity, TDto>(this ContainerBuilder builder)
     where TEntity : class, IBaseEntity, new()
     where TDto : class, IBaseDto, new()
        {
            builder.RegisterType<CommandTransactionProccessor<CreateCommandRequest<TEntity, TDto>, CommandResponse<TDto>, TEntity, TDto>>()
              .As<IPipelineBehavior<CreateCommandRequest<TEntity, TDto>, CommandResponse<TDto>>>();

            builder.RegisterType<CommandTransactionProccessor<DeleteCommandRequest<TEntity, TDto>, CommandResponse<TDto>, TEntity, TDto>>()
                                .As<IPipelineBehavior<DeleteCommandRequest<TEntity, TDto>, CommandResponse<TDto>>>();

            builder.RegisterType<CommandTransactionProccessor<UpdateCommandRequest<TEntity, TDto>, CommandResponse<TDto>, TEntity, TDto>>()
                                .As<IPipelineBehavior<UpdateCommandRequest<TEntity, TDto>, CommandResponse<TDto>>>();
            return builder;
        }

        public static ContainerBuilder RegisterPreCommandProccessors<TEntity, TDto>(this ContainerBuilder builder)
  where TEntity : class, IBaseEntity, new()
  where TDto : class, IBaseDto, new()
        {
            builder.RegisterType<CommandProccessor<CreateCommandRequest<TEntity, TDto>, CommandResponse<TDto>, TEntity, TDto>>()
              .As<IPipelineBehavior<CreateCommandRequest<TEntity, TDto>, CommandResponse<TDto>>>();

            builder.RegisterType<CommandProccessor<DeleteCommandRequest<TEntity, TDto>, CommandResponse<TDto>, TEntity, TDto>>()
                                .As<IPipelineBehavior<DeleteCommandRequest<TEntity, TDto>, CommandResponse<TDto>>>();

            builder.RegisterType<CommandProccessor<UpdateCommandRequest<TEntity, TDto>, CommandResponse<TDto>, TEntity, TDto>>()
                                .As<IPipelineBehavior<UpdateCommandRequest<TEntity, TDto>, CommandResponse<TDto>>>();
            return builder;
        }

    }
}
