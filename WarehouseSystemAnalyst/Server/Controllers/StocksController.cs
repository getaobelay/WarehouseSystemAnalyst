using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Mediator.Commands.Requests.CommonRequests;
using WarehouseSystemAnalyst.Mediator.Containers;
using WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos;
using WarehouseSystemAnalyst.Mediator.Queries.Requests.CommonRequests;
using WarehouseSystemAnalyst.Server.BaseContollers;
using WarehouseSystemAnalyst.Server.Interfaces;

namespace WarehouseSystemAnalyst.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase, IAPIController<ProductDto>
    {
        private readonly IMediator mediator;
        public StocksController() => MediatorContainer.BuildMediator();

        public virtual async Task<ActionResult<IBaseResponse<ProductDto>>> GetAllAsync()
        {
            try
            {
                var query = new ListQueryRequest<Product, ProductDto>();
                var result = await mediator.Send(query);

                if (result.Error)
                {
                    return Ok(BaseResponseHelper<ProductDto>.NullResponse(result.ErrorMessages));
                }

                return Ok(BaseResponseHelper<ProductDto>.ListResponse(result.Dtos));

            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        public virtual async Task<ActionResult<IBaseResponse<ProductDto>>> GetAsync(object Id)
        {
            try
            {
                var query = new SingleQueryRequest<Product, ProductDto>()
                {
                    Id = Id
                };

                var result = await mediator.Send(query);

                if (result.Error)
                {
                    return Ok(BaseResponseHelper<ProductDto>.NullResponse(result.ErrorMessages));
                }

                return Ok(BaseResponseHelper<ProductDto>.SingleResponse(result.Dto));

            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        public virtual async Task<ActionResult<IBaseResponse<ProductDto>>> PostAsync(ProductDto createdObject)
        {
            try
            {
                var query = new CreateCommandRequest<Product, ProductDto>()
                {
                    CreateObject = createdObject
                };

                var result = await mediator.Send(query);

                if (result.Error)
                {
                    return Ok(BaseResponseHelper<ProductDto>.NullResponse(result.ErrorMessages));
                }

                return Ok(BaseResponseHelper<ProductDto>.SingleResponse(result.Dto));

            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        public virtual async Task<ActionResult<IBaseResponse<ProductDto>>> PutAsync(object Id, ProductDto updatedObject)
        {
            var query = new UpdateCommandRequest<Product, ProductDto>()
            {
                Id = Id,
                UpdatedObject = updatedObject
            };

            var result = await mediator.Send(query);

            if (result.Error)
            {
                return Ok(BaseResponseHelper<ProductDto>.NullResponse(result.ErrorMessages));
            }

            return Ok(BaseResponseHelper<ProductDto>.SingleResponse(result.Dto));

        }

        public virtual async Task<ActionResult<IBaseResponse<ProductDto>>> DeleteAsync(object Id)
        {
            try
            {
                var query = new DeleteCommandRequest<Product, ProductDto>()
                {
                    Id = Id
                };

                var result = await mediator.Send(query);

                if (result.Error)
                {
                    return Ok(BaseResponseHelper<ProductDto>.NullResponse(result.ErrorMessages));
                }

                return Ok(BaseResponseHelper<ProductDto>.SingleResponse(result.Dto));

            }

            catch (Exception)
            {

                return StatusCode(500);
            }
        }

    }
}
