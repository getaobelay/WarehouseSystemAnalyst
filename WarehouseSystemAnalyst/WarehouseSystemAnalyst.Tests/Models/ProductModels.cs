using WarehouseSystemAnalyst.Data.Entities.ProductEntities;

namespace WarehouseSystemAnalyst.DataTests1.Models
{
    public static partial class TestModels
    {
        public static Batch Batch => new Batch
        {
            PK = "Batch1",
        };

        public static Category Category => new Category
        {
            PK = "Category1",
            Name = "test",
            SubCategoryID = SubCategory.PK,
            ProductID = Product.PK
        };

        public static Mesure Mesure => new Mesure
        {
            PK = "Mesure1",
        };

        public static Package Package => new Package
        {
            PK = "Package1",
            Type = "Box"
        };

        public static Product Product => new Product
        {
            ProductName = "TestProduct1",
            PK = "Id1",
        };

        public static ProductItem ProductItem => new ProductItem
        {
            PK = "ProductItem1",
            ProductName = "item1",
            Metrial = "met",
            BuyPricePerUnit = 12,
            SellPricePerUnit = 14,
        };

        public static ProductMesures ProductMesures => new ProductMesures
        {
            PK = "ProductMesures1",
            QuantityPerUnit = 10m,
            Height = 124m,
            Weight = 155m,
            UnitBuyPrice = 12m,
            UnitSellPrice = 15m
        };

        public static ProductPackages ProductPackages => new ProductPackages
        {
            PK = "ProductPackages1",
        };

        public static SubCategory SubCategory => new SubCategory
        {
            PK = "SubCategory1",
            CategoryId = Category.PK,
            Description = "Parts",
            Name = "Test1"
        };
    }
}