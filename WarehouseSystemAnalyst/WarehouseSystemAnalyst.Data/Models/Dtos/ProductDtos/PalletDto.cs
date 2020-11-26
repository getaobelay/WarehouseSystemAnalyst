namespace WarehouseSystemAnalyst.Data.Models.Dtos.ProductDtos
{
    public class PalletDto
    {

        public string PalletID { get; set; }
        public string PalletNumber { get; set; }
        public ProductDto Product { get; set; }
        public BatchDto Batch { get; set; }
    }
}
