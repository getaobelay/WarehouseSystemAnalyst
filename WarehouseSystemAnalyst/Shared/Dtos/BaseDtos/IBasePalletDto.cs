using WarehouseSystemAnalyst.Shared.Dtos.BaseDtos;

namespace WarehouseSystemAnalyst.Shared.Dtos
{
    public interface IBasePalletDto : IBaseDto
    {
        public string SupplierPallet { get; set; }
        public string PalletNumber { get; set; }
        public string PalletCode { get; set; }
    }
}