namespace WarehouseSystemAnalyst.Mediator.Dtos
{
    public abstract class BasePalletDto : BaseDto, IBasePalletDto
    {
        public string SupplierPallet { get; set; }
        public string PalletNumber { get; set; }
        public string PalletCode { get; set; }
    }

    public interface IBasePalletDto
    {
        public string SupplierPallet { get; set; }
        public string PalletNumber { get; set; }
        public string PalletCode { get; set; }
    }
}