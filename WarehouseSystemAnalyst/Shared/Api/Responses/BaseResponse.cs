using System.Collections.Generic;
using WarehouseSystemAnalyst.Shared.Dtos.BaseDtos;

namespace WarehouseSystemAnalyst.Shared.Api.Responses
{
    public static class ResponseHelper<TResponseDto>
          where TResponseDto : class, IBaseDto, new()
    {
        public static BaseResponse<TResponseDto> NullResponse(IEnumerable<string> errorsMessages) =>
            new BaseResponse<TResponseDto>(@object: null, success: false, errorsMessages: errorsMessages);
        public static BaseResponse<TResponseDto> ListResponse(IEnumerable<TResponseDto> responseDtos) =>
            new BaseResponse<TResponseDto>(@object: responseDtos, true, default);
        public static BaseResponse<TResponseDto> SingleResponse(TResponseDto response) =>
                  new BaseResponse<TResponseDto>(response, true, default);
    }

    public class BaseResponse<TResponseDto> : IBaseResponse<TResponseDto>
        where TResponseDto : class, IBaseDto, new()
    {
        public BaseResponse(object @object, bool success, IEnumerable<string> errorsMessages)
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