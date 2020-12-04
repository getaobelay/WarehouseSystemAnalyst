using System.Collections.Generic;

namespace WarehouseSystemAnalyst.Mediator.Interfaces.Responses
{
    public interface ITransactionCommandResponse<TSourceModel, TDestinationModel>
        where TSourceModel : class, new()
        where TDestinationModel : class, new()
    {
        public TSourceModel sourceModel { get; set; }
        public TDestinationModel DestinationModel { get; set; }
        public bool Error { get; set; }
        public List<string> Messages { get; set; }
    }
}