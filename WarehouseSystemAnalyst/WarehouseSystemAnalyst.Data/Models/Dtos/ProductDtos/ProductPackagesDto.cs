namespace WarehouseSystemAnalyst.Data.Models.Dtos.ProductDtos
{
    public class ProductPackagesDto
    {
        public string ProductID { get; set; }

        public string PackageType { get; set; }
        public string Quantity { get; set; }

        public ProductDto Product { get; set; }
        public PackageDto Package { get; set; }
    }
}