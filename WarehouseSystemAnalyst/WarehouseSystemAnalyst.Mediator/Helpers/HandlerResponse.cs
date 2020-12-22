using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Shared.Dtos.BaseDtos;

namespace WarehouseSystemAnalyst.Mediator.Helpers
{
    public static class HandlerResponse
    {
        public static HandlerResponse<TDto> NullResponse<TDto>(IEnumerable<string> errorsMessages)
            where TDto : class, IBaseDto, new() =>
            new HandlerResponse<TDto>(@object: null,
                                      success: false,
                                      errorsMessages: errorsMessages);

        public static HandlerResponse<TDto> ListResponse<TDto>(IEnumerable<TDto> responseDtos)
            where TDto : class, IBaseDto, new() =>
            new HandlerResponse<TDto>(@object: responseDtos,
                                      true,
                                      default);
        public static HandlerResponse<TDto> SingleResponse<TDto>(TDto response)
             where TDto : class, IBaseDto, new() =>
             new HandlerResponse<TDto>(response,
                                       true,
                                       default);
    }

    public class HandlerResponse<TDto> : IHandlerResponse<TDto>
        where TDto : class, IBaseDto, new()
    {
        public HandlerResponse(object @object, bool success, IEnumerable<string> errorsMessages)
        {
            Object = @object;
            Success = success;
            ErrorsMessages = errorsMessages;
        }

        public object Object { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> ErrorsMessages { get; set; }
    }

}
