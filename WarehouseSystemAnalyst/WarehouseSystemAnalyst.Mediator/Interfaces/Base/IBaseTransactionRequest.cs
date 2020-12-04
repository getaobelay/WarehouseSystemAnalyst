namespace WarehouseSystemAnalyst.Mediator.Interfaces.Base
{
    public interface IBaseTransactionRequest<TSourcenRequest, TSourcenResponse, TDestinationRequest, TDestinationResponse>
        where TSourcenRequest : class, new()
        where TSourcenResponse : class, new()
        where TDestinationRequest : class, new()
        where TDestinationResponse : class, new()
    {
        public object SourceId { get; set; }
        public object DestinationId { get; set; }
        public TDestinationResponse Source { get; set; }
        public TDestinationResponse Destination { get; set; }

    }
}