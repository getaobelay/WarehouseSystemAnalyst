using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Requests;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Queries.Requests;
using WarehouseSystemAnalyst.Shared.Dtos.ProductDtos;
using WarehouseSystemAnalyst.Mediator.loC;
using WarehouseSystemAnalyst.Server.Interfaces;
using WarehouseSystemAnalyst.Shared.Api.Responses;

namespace WarehouseSystemAnalyst.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase, IAPIController<ProductDto>
    {
        private readonly IMediator mediator;

        public IMediator Mediator => mediator;

        public ProductsController()
        {
            mediator = MediatorContainer.BuildMediator();
        }

        [HttpGet]
        public async Task<ActionResult<IBaseResponse<ProductDto>>> GetAllAsync()
        {
            try
            {
                var query = new ListQueryRequest<Product, ProductDto>();
                var result = await Mediator.Send(query);


                if (result.Success)
                {
                    return Ok(ResponseHelper<ProductDto>.ListResponse((IEnumerable<ProductDto>)result.Object));

                }
                return Ok(ResponseHelper<ProductDto>.NullResponse(result.ErrorsMessages));

            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<IBaseResponse<ProductDto>>> GetByIdAsync([FromRoute] string Id)
        {
            try
            {
                var query = new SingleQueryRequest<Product, ProductDto>()
                {
                    Id = Id,
                    Filter = p => p.PK == Id
                };

                var result = await Mediator.Send(query);

                if (result.Success)
                {
                    return Ok(ResponseHelper<ProductDto>.SingleResponse((ProductDto)result.Object));

                }
                return Ok(ResponseHelper<ProductDto>.NullResponse(result.ErrorsMessages));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpPost]
        public  async Task<ActionResult<IBaseResponse<ProductDto>>> PostAsync([FromBody] ProductDto createdObject)
        {

            var query = new CreateCommandRequest<Product, ProductDto>()
            {
                CreateObject = createdObject
            };

            var result = await Mediator.Send(query);

            if (result.Error)
            {
                return Ok(ResponseHelper<ProductDto>.NullResponse(result.ErrorMessages));
            }

            return Ok(ResponseHelper<ProductDto>.SingleResponse(result.Dto));



        }

        [HttpPut("{Id}")]
        public  async Task<ActionResult<IBaseResponse<ProductDto>>> PutAsync([FromRoute] string Id, [FromBody] ProductDto updatedObject)
        {
            var query = new UpdateCommandRequest<Product, ProductDto>()
            {
                Id = Id,
                UpdatedObject = updatedObject
            };

            var result = await Mediator.Send(query);

            if (result.Error)
            {
                return Ok(ResponseHelper<ProductDto>.NullResponse(result.ErrorMessages));
            }

            return Ok(ResponseHelper<ProductDto>.SingleResponse(result.Dto));

        }

        [HttpDelete("{Id}")]
        public  async Task<ActionResult<IBaseResponse<ProductDto>>> DeleteAsync([FromRoute] string Id)
        {
            try
            {
                var query = new DeleteCommandRequest<Product, ProductDto>()
                {
                    Id = Id
                };

                var result = await Mediator.Send(query);

                if (result.Error)
                {
                    return Ok(ResponseHelper<ProductDto>.NullResponse(result.ErrorMessages));
                }

                return Ok(ResponseHelper<ProductDto>.SingleResponse(result.Dto));
            }

            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}
