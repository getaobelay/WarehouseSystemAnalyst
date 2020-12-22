using System.Collections.Generic;
using WarehouseSystemAnalyst.Shared.Dtos.BaseDtos;

namespace WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Responses
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

    public abstract class BaseCommandResponse<TDto> : ICommandResponse<TDto>
        where TDto : class, IBaseDto, new()
    {
        public TDto Dto { get; set; }
        public bool Error { get; set; }
        public List<string> ErrorMessages { get; set; }

    }
    public class CommandResponse<TDto> : BaseCommandResponse<TDto>
        where TDto : class, IBaseDto, new()
    {
        public CommandResponse(TDto model, List<string> messages, bool error)
        {
            Error = error;
            Dto = model;
            ErrorMessages = messages;
        }
    }
}