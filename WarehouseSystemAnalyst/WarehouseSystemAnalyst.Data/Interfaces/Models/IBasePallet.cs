namespace WarehouseSystemAnalyst.Data.Interfaces.Models
{
    public interface IBasePallet : IBaseEntity
    {
        public string SupplierPallet { get; set; }
        public string PalletNumber { get; set; }
        public string PalletCode { get; set; }
    }
}