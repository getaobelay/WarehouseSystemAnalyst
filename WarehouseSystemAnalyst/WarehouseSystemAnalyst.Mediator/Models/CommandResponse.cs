using System;
using WarehouseSystemAnalyst.Interfaces.CQRS.Models;

namespace WarehouseSystemAnalyst.Mediator.Models
{
    public static class CommandResponse
    {
        public static CommandResponse<TModel> CommandFailed<TModel>(string message, TModel model = default)
            where TModel : class, new()
        {
            return new CommandResponse<TModel>(model: model, message: message, error: true);
        }

        public static CommandResponse<TModel> CommandExecuted<TModel>(string message, TModel model)
            where TModel : class, new()
        {
            return new CommandResponse<TModel>(model: model, message: message, error: false);
        }
    }

    public class CommandResponse<TModel> : ICommandResponse<TModel>
        where TModel : class, new()
    {
        public CommandResponse(TModel model, string message, bool error)
        {
            Error = error;
            Model = model;
            Message = message;
        }

        public bool Error { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public TModel Model { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Message { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
