namespace WarehouseSystemAnalyst.Mediator.Dtos
{
    public interface IBasePalletDto : IBaseDto
    {
        public string SupplierPallet { get; set; }
        public string PalletNumber { get; set; }
        public string PalletCode { get; set; }
    }
}