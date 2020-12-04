namespace WarehouseSystemAnalyst.Mediator.Models
{
    public static class InventoryResponse
    {
        //public static InventoryResponse<TModel> QuantityAvailable<TModel>(string message, TModel model, int avaiableQuantity, int availableItems)
        //    where TModel : class, new()
        //{
        //    return new InventoryResponse<TModel>(model: model, message: message, error: false, availableItems: availableItems, avaiableQuantity: avaiableQuantity);
        //}

        //public static InventoryResponse<TModel> QuantityNotAvailable<TModel>(string message, TModel model, int avaiableQuantity)
        //    where TModel : class, new()
        //{
        //    return new InventoryResponse<TModel>(model: model, message: message, error: true, availableItems: 0, avaiableQuantity: avaiableQuantity);
        //}
    }

    //public class InventoryResponse<TModel> : CommandResponse<TModel>, IQuantityResponse<TModel>
    //    where TModel : class, new()
    //{
    //    public InventoryResponse(TModel model, string message, bool error) : base(model, message, error)
    //    {
    //    }

    //    public InventoryResponse(int avaiableQuantity, int availableItems, TModel model, string message, bool error) : base(model, message, error)
    //    {
    //        AvailableQuantity = avaiableQuantity;
    //        AvailableItems = availableItems;
    //    }

    //    public int AvailableQuantity { get; set; }
    //    public int AvailableItems { get; set; }

    //}
}