using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Commands.Requests;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.Commands.Behaviours
{
    public class TransacitonCommandBehaviour<TRequest, TResponse, TSourceEntity, TSourceDto, TDestEntity, TDestDto> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ITransactionCommand<TSourceEntity, TSourceDto, TDestEntity, TDestDto>
        where TResponse : ITransactionResponse<TSourceDto, TDestDto>
        where TSourceEntity : class, IBaseEntity, new()
        where TSourceDto : class, IBaseDto, new()
        where TDestEntity : class, IBaseEntity, new()
        where TDestDto : class, IBaseDto, new()
    {
        private readonly ILogger<TransacitonCommandBehaviour<TRequest, TResponse, TSourceEntity, TSourceDto, TDestEntity, TDestDto>> _logger;
        public TransacitonCommandBehaviour(ILogger<TransacitonCommandBehaviour<TRequest, TResponse, TSourceEntity, TSourceDto, TDestEntity, TDestDto>> logger, IDataContext context)
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
                await Context.UnitOfWork.CreateTransactionAsync();
                _logger.LogInformation($"Begin transaction {typeof(TRequest).Name}");

                response = await next();

                await Context.UnitOfWork.CommitAsync();
                _logger.LogInformation($"Committed transaction {typeof(TRequest).Name}");

                return response;
            }

            catch (Exception e)
            {
                _logger.LogInformation($"Rollback transaction executed {typeof(TRequest).Name}");

                await Context.UnitOfWork.RollbackAsync();

                _logger.LogError(e.Message, e.StackTrace);

                throw;
            }
        }
    }
}
