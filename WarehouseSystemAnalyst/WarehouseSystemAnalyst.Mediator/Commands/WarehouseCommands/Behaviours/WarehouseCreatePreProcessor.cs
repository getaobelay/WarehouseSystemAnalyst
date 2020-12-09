using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Commands.Requests;
using WarehouseSystemAnalyst.Mediator.Commands.StockCommands.Requests;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.Common.Behaviours
{
    /// <summary>
    /// preprocessor
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <typeparam name="TSourceDto"></typeparam>
    /// <typeparam name="TDestDto"></typeparam>
    public class WarehouseCreatePreProcessor<TRequest, TResponse, TSourceEntity, TSourceDto, TDestEntity, TDestDto> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : CreateWarehouseCommand<TSourceEntity, TSourceDto, TDestEntity, TDestDto>
        where TSourceEntity : class, IBaseWarehouse, new()
        where TSourceDto : class, IBaseWarehouseDto, new()
        where TDestEntity : class, IBaseWarehouse, new()
        where TDestDto : class, IBaseWarehouseDto, new()
    {
        private readonly ILogger<WarehouseCreatePreProcessor<TRequest, TResponse, TSourceEntity, TSourceDto, TDestEntity, TDestDto>> _logger;
        public WarehouseCreatePreProcessor(ILogger<WarehouseCreatePreProcessor<TRequest, TResponse, TSourceEntity, TSourceDto, TDestEntity, TDestDto>> logger)
        {
            _logger = logger ?? throw new ArgumentException(nameof(ILogger));
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            TResponse response = default;

            TDestDto destiantion = new TDestDto();
            TSourceDto source = new TSourceDto();

            try
            {
                response = await next();

                _logger.LogInformation($"Committed transaction {typeof(TRequest).Name}");

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
