namespace WarehouseSystemAnalyst.Data.Entities.BaseEntites
{
    public interface IBasePallet : IBaseEntity
    {
        public string SupplierPallet { get; set; }
        public string PalletNumber { get; set; }
        public string PalletCode { get; set; }
    }
}