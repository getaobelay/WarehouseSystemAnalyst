using System.Collections.ObjectModel;
using WarehouseSystemAnalyst.Data.Entities.PalletEntities;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Data.Entities.SupplyChainEntities;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;

namespace WarehouseSystemAnalyst.DataTests1.Models
{
    public static partial class TestModels
    {
        public static Batch Batch => new Batch
        {
            PK = "Batch1",
            ProductID = Product.PK,
            PalletID = ProductPallet.PK,
            ProductItemId = ProductItem.PK,
            StockId = Stock.PK,
            InventoryId = Inventory.PK,
            ProductSupplierID = ProductVendor.PK
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
            ProductItemId = ProductItem.PK,
            ProductMesureId = ProductMesures.PK,
            ProductItems = new Collection<ProductItem> { ProductItem },
            ProductMesures = new Collection<ProductMesures> { ProductMesures }
        };
        public static Package Package => new Package
        {
            PK = "Package1",
            ProductPackageID = ProductPackages.PK,
            ProductPackages = new Collection<ProductPackages> { ProductPackages },
            Type = "Box"
        };
        public static Product Product => new Product
        {
            ProductName = "TestProduct1",
            PK = "Id1",
            BatchAK = Batch.PK,
            Batches = new Collection<Batch> { Batch },
            ProductItemAK = ProductItem.PK,
            ProductItems = new Collection<ProductItem> { ProductItem },
            MesureAK = Mesure.PK,
            Mesures = new Collection<ProductMesures> { ProductMesures },
            CategoryAK = Category.PK,
            Category = Category,
            ProductPackageAK = ProductPackages.PK,
            ProductPackages = new Collection<ProductPackages> { ProductPackages },
            ProductVendorAK = ProductVendor.PK,
            ProductVendors = new Collection<ProductVendor> { ProductVendor },
            InventoryAK = Inventory.PK,
            Inventory = Inventory,
            StockAK = Stock.PK,
            Stock = Stock,
            PalletAK = ProductPallet.PK,
            Pallets = new Collection<ProductPallet> { ProductPallet },
            WarehouseItemAK = WarehouseItem.PK,
            WarehouseItems = new Collection<WarehouseItem> { WarehouseItem }
        };
        public static ProductItem ProductItem => new ProductItem
        {
            PK = "ProductItem1",
            BatchId = Batch.PK,
            MesureId = Mesure.PK,
            ProductName = "item1",
            Metrial = "met",
            BuyPricePerUnit = 12,
            SellPricePerUnit = 14,
            ProductId = Product.PK
        };
        public static ProductMesures ProductMesures => new ProductMesures
        {
            MesureID = Mesure.PK,
            Mesure = Mesure,
            ProductID = Product.PK,
            QuantityPerUnit = 10m,
            Height = 124m,
            Weight = 155m,
            UnitBuyPrice = 12m,
            UnitSellPrice = 15m
        };
        public static ProductPackages ProductPackages => new ProductPackages
        {
            PK = "ProductPackages1",
            ProductID = Product.PK,
            PackageID = Package.PK,
            ProductItemID = ProductItem.PK
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
