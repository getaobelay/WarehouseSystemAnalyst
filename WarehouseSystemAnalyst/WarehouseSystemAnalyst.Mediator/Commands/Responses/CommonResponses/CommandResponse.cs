using System.Collections.Generic;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.Commands.Responses.CommonResponses
{
    public static class CommandResponse
    {
        public static CommandResponse<TDto> CommandFailed<TDto>(string message, TDto model = default)
            where TDto : class, IBaseDto, new()
        {
            return new CommandResponse<TDto>(model: model, messages: new List<string>() { message }, error: true);
        }

        public static CommandResponse<TDto> CommandExecuted<TDto>(string message, TDto model)
            where TDto : class, IBaseDto, new()
        {
            return new CommandResponse<TDto>(model: model, messages: new List<string>() { message }, error: false);
        }
    }

    public class CommandResponse<TDto>
        where TDto : class, IBaseDto, new()
    {
        public CommandResponse(TDto model, List<string> messages, bool error)
        {
            Error = error;
            Dto = model;
            ErrorMessages = messages;
        }
        public TDto Dto { get; set; }
        public bool Error { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}