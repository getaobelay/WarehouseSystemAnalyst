using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Context;
using WarehouseSystemAnalyst.Interfaces.Base;

namespace WarehouseSystemAnalyst.Services.Base
{
    public class BaseController<TRequestModel, TResponseModel, TResponse, TRequest> :
        IBaseController<TRequestModel, TResponseModel, TResponse, TRequest>
        where TRequestModel : class, new()
        where TResponseModel : class, new()
        where TResponse : class, IBaseResponse<TResponseModel>, new()
        where TRequest : class, IBaseRequest<TRequestModel, TResponseModel>, new()
    {
        private readonly BaseRepository<TRequestModel> _repository;

        protected BaseController(BaseRepository<TRequestModel> repository)
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
