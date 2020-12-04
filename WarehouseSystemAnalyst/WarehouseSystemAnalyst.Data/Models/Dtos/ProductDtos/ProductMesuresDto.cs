namespace WarehouseSystemAnalyst.Data.Models.Dtos.ProductDtos
{
    public class ProductMesuresDto
    {
        public int ProductMesuresID { get; set; }
        public string ProductName { get; set; }
        public string Measurement { get; set; }
        public int Quantity { get; set; }
        public ProductDto Product { get; set; }
        public MesureDto Mesure { get; set; }
    }
}