using System.Collections.Generic;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.Models
{
    public static class CommandResponse
    {
        public static CommandResponse<TModel> CommandFailed<TModel>(string message, TModel model = default)
            where TModel : BaseDto, new()
        {
            return new CommandResponse<TModel>(model: model, messages: new List<string>() { message }, error: true);
        }

        public static CommandResponse<TModel> CommandExecuted<TModel>(string message, TModel model)
            where TModel : BaseDto, new()
        {
            return new CommandResponse<TModel>(model: model, messages: new List<string>() { message }, error: false);
        }
    }

    public class CommandResponse<TModel> : ICommandResponse<TModel>
        where TModel : BaseDto, new()
    {
        public CommandResponse(TModel model, List<string> messages, bool error)
        {
            Error = error;
            Dto = model;
            Messages = messages;
        }

        public TModel Dto { get; set; }
        public bool Error { get; set; }
        public List<string> Messages { get; set; }
    }
}