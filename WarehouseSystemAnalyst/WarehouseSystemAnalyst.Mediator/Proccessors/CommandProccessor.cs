using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Requests;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Responses;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;
using WarehouseSystemAnalyst.Shared.Dtos.BaseDtos;

namespace WarehouseSystemAnalyst.Mediator.Proccessors
{
    public class CommandProccessor<TRequest, TResponse, TEntity, TDto> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : BaseCommandRequest<TEntity, TDto>
        where TResponse : BaseCommandResponse<TDto>
        where TEntity : class, IBaseEntity, new()
        where TDto : class, IBaseDto, new()
    {
        private readonly ILogger<CommandProccessor<TRequest, TResponse, TEntity, TDto>> _logger;
        public CommandProccessor(ILogger<CommandProccessor<TRequest, TResponse, TEntity, TDto>> logger, IDataContext context)
        {
            _logger = logger ?? throw new ArgumentException(nameof(ILogger));
            Context = context;
        }

        public IDataContext Context { get; }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            TResponse response = default;

            try
            {
                if (Context.CurrentUser.IsAuthenticated())
                {
                    var username = Context.CurrentUser.GetUsername();

                    if (request is CreateCommandRequest<TEntity, TDto> createCommand)
                    {
                        createCommand.CreateObject.CreatedBy = username;
                        createCommand.CreateObject.CreateDate = DateTime.UtcNow;
                        createCommand.CreateObject.ModifiedBy = username;
                        createCommand.CreateObject.ModifiedDate = DateTime.UtcNow;

                        response = await next();
                        return response;
                    }

                    else if (request is UpdateCommandRequest<TEntity, TDto> updateCommand)
                    {
                        updateCommand.UpdatedObject.ModifiedBy = username;
                        updateCommand.UpdatedObject.ModifiedDate = DateTime.UtcNow;

                        response = await next();
                        return response;
                    }

                    else
                    {
                        response = await next();
                        return response;
                    }


                }

                response.Error = true;
                response.ErrorMessages = new List<string>() { "User is not authenticated" };
                return response;
            }

            catch (Exception e)
            {
                _logger.LogInformation($"Rollback transaction executed {typeof(TRequest).Name}");
                _logger.LogError(e.Message, e.StackTrace);
                throw;
            }
        }
    }
}
