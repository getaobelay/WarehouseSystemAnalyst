using System.Collections.Generic;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.CommonCQRS.Queries.Responses
{
    public class SingleQueryResponse<TDto>
        where TDto : class, IBaseDto, new()
    {
        public TDto Dto { get; set; }
        public bool Error { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}