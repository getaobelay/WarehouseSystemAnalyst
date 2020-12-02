using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;
using WarehouseSystemAnalyst.Data.Implementation.BaseRepositories;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Interfaces.Base;

namespace WarehouseSystemAnalyst.Data.Implementation.BaseApi
{
    public class BaseController<TRequestModel, TResponseModel, TResponse, TRequest> :
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
        public Task<ActionResult<TResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{Id}")]
        public Task<ActionResult<TResponse>> GetAsync(object Id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task<ActionResult<TResponse>> PostAsync(TResponseModel entityToUpdate)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{Id}")]
        public Task<ActionResult<TResponse>> PutAsync(object Id, TResponseModel entity)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public Task<ActionResult<TResponse>> DeleteAsync(object Id)
        {
            throw new NotImplementedException();
        }
    }
}