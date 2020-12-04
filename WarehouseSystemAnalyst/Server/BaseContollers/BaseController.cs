using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;
using WarehouseSystemAnalyst.Data.Implementation.BaseRepositories;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Helpers;
using WarehouseSystemAnalyst.Mediator.Interfaces.Base;
using WarehouseSystemAnalyst.Server.Interfaces.Base;

namespace WarehouseSystemAnalyst.Server.BaseContollers
{
    public class BaseController<TRequestModel, TResponseModel, TResponse, TRequest> : ControllerBase,
        IBaseController<TRequestModel, TResponseModel, TResponse, TRequest>
        where TRequestModel : class, IBaseEntity, new()
        where TResponseModel : BaseDtoModel, new()
        where TResponse : class, IBaseResponse<TResponseModel>, new()
        where TRequest : class, IBaseRequest<TRequestModel, TResponseModel>, new()
    {
        private readonly BaseDataRepository<TRequestModel> _repository;

        protected BaseController(BaseDataRepository<TRequestModel> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<TResponse>> GetAllAsync()
        {
            try
            {
                var result = await _repository.GetAllAsync();
                var mapped = MappingHelper.Mapper.Map<TResponseModel>(result);
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
                        Data = MappingHelper.Mapper.Map<TResponseModel>(result),
                        Success = true
                    });
                }

                else
                {
                    return Ok(new TResponse()
                    {
                        Data = null,
                        Success = false,
                        ErrorMessages = { $"{nameof(TResponseModel)} with id {Id} not found" }
                    });
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpPost]
        public async Task<ActionResult<TResponse>> PostAsync(TResponseModel entityToUpdate)
        {
            try
            {
                var mapped = MappingHelper.Mapper.Map<TRequestModel>(entityToUpdate);
                var result = await _repository.InsertAsync(mapped);
                var resultFrom = await _repository.GetSingleQuery(t => t.PK == result.PK);

                if (resultFrom != null)
                {
                    return Ok(new TResponse()
                    {
                        Data = MappingHelper.Mapper.Map<TResponseModel>(resultFrom),
                        Success = true
                    });
                }

                else
                {
                    return Ok(new TResponse()
                    {
                        Data = null,
                        Success = false,
                        ErrorMessages = { $"created {nameof(TResponseModel)} not found after creation of the record" }
                    });
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpPost("{Id}")]
        public async Task<ActionResult<TResponse>> PutAsync(object Id, TResponseModel entity)
        {
            if (!Id.Equals(entity.PK))
                return Ok(new TResponse()
                {
                    Data = null,
                    Success = false,
                    ErrorMessages = { $"{nameof(TResponseModel)} Id and {Id.ToString()} from the route should be equal" }
                }
                );

            try
            {
                var mapped = MappingHelper.Mapper.Map<TRequestModel>(entity);
                         var result = await _repository.UpdateAsync(mapped);
                var resultFrom = await _repository.GetSingleQuery(t => t.PK == result.PK);

                if (resultFrom != null)
                {
                    return Ok(new TResponse()
                    {
                        Data = MappingHelper.Mapper.Map<TResponseModel>(resultFrom),
                        Success = true
                    });
                }

                else
                {
                    return Ok(new TResponse()
                    {
                        Data = null,
                        Success = false,
                        ErrorMessages = { $"{nameof(TResponseModel)} with id {Id} not found after creation of the record" }
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
                        ErrorMessages = { $"{nameof(TResponseModel)} with id {Id} found after delete of the record" }
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