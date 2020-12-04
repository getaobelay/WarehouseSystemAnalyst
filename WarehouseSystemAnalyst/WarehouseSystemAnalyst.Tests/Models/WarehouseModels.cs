using System.Collections.ObjectModel;
using WarehouseSystemAnalyst.Data.Entities.ContactEntities;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites.WarehouseTypes;

namespace WarehouseSystemAnalyst.DataTests1.Models
{
    public static partial class TestModels
    {
        public static WarehouseItem WarehouseItem => new WarehouseItem
        {
            PK = "WarehouseItemTest1",
            EmployeeID = Employee.PK,
            Employee = Employee,
            GoodsWarehouseId = GoodsWarehouse.PK,
            GoodsWarehouse = GoodsWarehouse,
            LocationID = Location.PK,
            Location = Location,
            BatchID = Batch.PK,
            AllocationId = Allocation.PK,
            Allocation = Allocation,
            AllocationWarehouseId = AllocationWarehouse.PK,
            AllocationWarehouse = AllocationWarehouse,
            ShippingWarhouseId = ShippingWarehouse.PK,
            ShippingWarehouse = ShippingWarehouse,
            ProductID = Product.PK,
            ProductMesureId = ProductMesures.PK,
            ProductPackageID = ProductPackages.PK
        };

        public static ShippingWarehouse ShippingWarehouse => new ShippingWarehouse
        {
            PK = "ShippingWarehouse1",
            LocationID = Location.PK,
            Locations = new Collection<Location> { Location },
            WarehouseName = "WarehouseTest"
        };

        public static AllocationWarehouse AllocationWarehouse => new AllocationWarehouse
        {
            PK = "AllocationWarehouse",
            LocationID = Location.PK,
            Locations = new Collection<Location> { Location },
            WarehouseName = "WarehouseTest"
        };

        public static GoodsWarehouse GoodsWarehouse => new GoodsWarehouse
        {
            PK = "GoodsWarehouse",
            LocationID = Location.PK,
            Locations = new Collection<Location> { Location },
            WarehouseName = "WarehouseTest"
        };

        public static Location Location => new Location
        {
            PK = "Location1",
            LocationRow = "A1",
            LocationColum = "01",
            LocationShelf = "02",
            GoodsWarehouseID = GoodsWarehouse.PK,
            ShippingWarehouseID = ShippingWarehouse.PK,
            AllocationWarehouseID = AllocationWarehouse.PK,
        };

        public static Allocation Allocation => new Allocation
        {
        };

        public static Employee Employee => new Employee
        {
            PK = "Employee1",
            LastName = "ln1",
            FirstName = "fn1"
        };
    }
}