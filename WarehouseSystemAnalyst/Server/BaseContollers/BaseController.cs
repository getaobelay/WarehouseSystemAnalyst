using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Implementation.Repositories;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Helpers;
using WarehouseSystemAnalyst.Mediator.Interfaces.Base;
using WarehouseSystemAnalyst.Server.Interfaces.Base;

namespace WarehouseSystemAnalyst.Server.BaseContollers
{
    public class BaseController<TRequestEntity, TResponseDto, TResponse, TRequest> : ControllerBase,
        IBaseController<TRequestEntity, TResponseDto, TResponse, TRequest>
        where TRequestEntity : class, IBaseEntity, new()
        where TResponseDto : class, IBaseDto, new()
        where TResponse : class, IBaseResponse<TResponseDto>, new()
        where TRequest : class, IBaseRequest<TRequestEntity, TResponseDto>, new()
    {
        private readonly DataRepository<TRequestEntity> _repository;

        private IMediator mediator;
        protected BaseController() => mediator ??= MediatorContainer.BuildMediator();
        public IMediator Mediator { get { return mediator; } }

        protected BaseController(DataRepository<TRequestEntity> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<TResponse>> GetAllAsync()
        {
            try
            {
                var result = await _repository.GetAllAsync();
                var mapped = MappingHelper.Mapper.Map<TResponseDto>(result);
                return Ok(new TResponse()
                {
                    Data = mapped,
                    Success = true,
                });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<TResponse>> GetAsync(object Id)
        {
            try
            {
                var result = await _repository.GetByIdAsync(Id);

                if (result != null)
                {
                    return Ok(new TResponse()
                    {
                        Data = MappingHelper.Mapper.Map<TResponseDto>(result),
                        Success = true
                    });
                }

                else
                {
                    return Ok(new TResponse()
                    {
                        Data = null,
                        Success = false,
                        ErrorMessages = { $"{nameof(TResponseDto)} with id {Id} not found" }
                    });
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpPost]
        public async Task<ActionResult<TResponse>> PostAsync(TResponseDto entityToUpdate)
        {
            try
            {
                var mapped = MappingHelper.Mapper.Map<TRequestEntity>(entityToUpdate);
                var result = await _repository.InsertAsync(mapped);
                var resultFrom = await _repository.GetSingleQuery(t => t.PK == result.PK);

                if (resultFrom != null)
                {
                    return Ok(new TResponse()
                    {
                        Data = MappingHelper.Mapper.Map<TResponseDto>(resultFrom),
                        Success = true
                    });
                }

                else
                {
                    return Ok(new TResponse()
                    {
                        Data = null,
                        Success = false,
                        ErrorMessages = { $"created {nameof(TResponseDto)} not found after creation of the record" }
                    });
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpPost("{Id}")]
        public async Task<ActionResult<TResponse>> PutAsync(object Id, TResponseDto entity)
        {
            if (!Id.Equals(entity.PK))
                return Ok(new TResponse()
                {
                    Data = null,
                    Success = false,
                    ErrorMessages = { $"{nameof(TResponseDto)} Id and {Id.ToString()} from the route should be equal" }
                }
                );

            try
            {
                var mapped = MappingHelper.Mapper.Map<TRequestEntity>(entity);
                         var result = await _repository.UpdateAsync(mapped);
                var resultFrom = await _repository.GetSingleQuery(t => t.PK == result.PK);

                if (resultFrom != null)
                {
                    return Ok(new TResponse()
                    {
                        Data = MappingHelper.Mapper.Map<TResponseDto>(resultFrom),
                        Success = true
                    });
                }

                else
                {
                    return Ok(new TResponse()
                    {
                        Data = null,
                        Success = false,
                        ErrorMessages = { $"{nameof(TResponseDto)} with id {Id} not found after creation of the record" }
                    });
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpDelete("Id")]
        public async Task<ActionResult<TResponse>> DeleteAsync(object Id)
        {
            try
            {
                var result = await _repository.DeleteAsync(Id);
                var resultFrom = await _repository.GetSingleQuery(t => t.PK == Id);

                if (resultFrom != null)
                {
                    return Ok(new TResponse()
                    {
                        Data = null,
                        Success = false,
                        ErrorMessages = { $"{nameof(TResponseDto)} with id {Id} found after delete of the record" }
                    });
                }

                else
                {
                    return Ok(new TResponse()
                    {
                        Data = null,
                        Success = true,
                    });
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
    }
}