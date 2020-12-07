using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseSystemAnalyst.Data.Migrations
{
    public partial class InitialDbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KeyValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValues = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCategoryID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => new { x.Id, x.PK });
                    table.UniqueConstraint("AK_Categories_PK", x => x.PK);
                });

            migrationBuilder.CreateTable(
                name: "CollectItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollectProductItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectProductItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollectProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseItemId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.UniqueConstraint("AK_Employees_PK", x => x.PK);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsQuanityAvailable = table.Column<bool>(type: "bit", nullable: false),
                    TotalUnitsQuantity = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ProductQuantity = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    BatchQuantity = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatchID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitsInInventory = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitsInOrder = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReorderLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GoodsWarehousesAK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllocationWarehouseAK = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => new { x.Id, x.PK });
                    table.UniqueConstraint("AK_Inventories_PK", x => x.PK);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationRow = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationColum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationShelf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllocationWarehouseID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoodsWarehouseID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingWarehouseID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseItemID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.UniqueConstraint("AK_Locations_PK", x => x.PK);
                });

            migrationBuilder.CreateTable(
                name: "Mesures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductMesureId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductItemId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesures", x => new { x.Id, x.PK });
                    table.UniqueConstraint("AK_Mesures_PK", x => x.PK);
                });

            migrationBuilder.CreateTable(
                name: "OrderPallet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierPallet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PalletNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PalletCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPallet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllocationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderPalletId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.UniqueConstraint("AK_Orders_PK", x => x.PK);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPackageID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => new { x.Id, x.PK });
                    table.UniqueConstraint("AK_Packages_PK", x => x.PK);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsQuanityAvailable = table.Column<bool>(type: "bit", nullable: false),
                    TotalUnitsQuantity = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ProductQuantity = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    BatchQuantity = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatchID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitsInStock = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReorderLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AllocationWarehouseAK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingWarehousesAK = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => new { x.Id, x.PK });
                    table.UniqueConstraint("AK_Stocks_PK", x => x.PK);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductVendorId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                    table.UniqueConstraint("AK_Vendors_PK", x => x.PK);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => new { x.Id, x.PK });
                    table.ForeignKey(
                        name: "FK_SubCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GoodsWarehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WarehouseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WarehouseItemID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatchID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InventoryId = table.Column<int>(type: "int", nullable: true),
                    InventoryPK = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsWarehouses", x => new { x.Id, x.PK });
                    table.UniqueConstraint("AK_GoodsWarehouses_PK", x => x.PK);
                    table.ForeignKey(
                        name: "FK_GoodsWarehouses_Inventories_InventoryId_InventoryPK",
                        columns: x => new { x.InventoryId, x.InventoryPK },
                        principalTable: "Inventories",
                        principalColumns: new[] { "Id", "PK" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Allocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    WarehouseItemID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allocations", x => x.Id);
                    table.UniqueConstraint("AK_Allocations_PK", x => x.PK);
                    table.ForeignKey(
                        name: "FK_Allocations_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderOrderPallet",
                columns: table => new
                {
                    OrderPalletsId = table.Column<int>(type: "int", nullable: false),
                    OrdersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderOrderPallet", x => new { x.OrderPalletsId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_OrderOrderPallet_OrderPallet_OrderPalletsId",
                        column: x => x.OrderPalletsId,
                        principalTable: "OrderPallet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderOrderPallet_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AllocationWarehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WarehouseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WarehouseItemID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatchID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InventoryId = table.Column<int>(type: "int", nullable: true),
                    InventoryPK = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StockId = table.Column<int>(type: "int", nullable: true),
                    StockPK = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllocationWarehouses", x => new { x.Id, x.PK });
                    table.UniqueConstraint("AK_AllocationWarehouses_PK", x => x.PK);
                    table.ForeignKey(
                        name: "FK_AllocationWarehouses_Inventories_InventoryId_InventoryPK",
                        columns: x => new { x.InventoryId, x.InventoryPK },
                        principalTable: "Inventories",
                        principalColumns: new[] { "Id", "PK" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AllocationWarehouses_Stocks_StockId_StockPK",
                        columns: x => new { x.StockId, x.StockPK },
                        principalTable: "Stocks",
                        principalColumns: new[] { "Id", "PK" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShippingWarehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WarehouseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WarehouseItemID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatchID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockId = table.Column<int>(type: "int", nullable: true),
                    StockPK = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingWarehouses", x => new { x.Id, x.PK });
                    table.UniqueConstraint("AK_ShippingWarehouses_PK", x => x.PK);
                    table.ForeignKey(
                        name: "FK_ShippingWarehouses_Stocks_StockId_StockPK",
                        columns: x => new { x.StockId, x.StockPK },
                        principalTable: "Stocks",
                        principalColumns: new[] { "Id", "PK" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GoodsWarehouseLocation",
                columns: table => new
                {
                    LocationsId = table.Column<int>(type: "int", nullable: false),
                    GoodsWarehousesId = table.Column<int>(type: "int", nullable: false),
                    GoodsWarehousesPK = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsWarehouseLocation", x => new { x.LocationsId, x.GoodsWarehousesId, x.GoodsWarehousesPK });
                    table.ForeignKey(
                        name: "FK_GoodsWarehouseLocation_GoodsWarehouses_GoodsWarehousesId_GoodsWarehousesPK",
                        columns: x => new { x.GoodsWarehousesId, x.GoodsWarehousesPK },
                        principalTable: "GoodsWarehouses",
                        principalColumns: new[] { "Id", "PK" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsWarehouseLocation_Locations_LocationsId",
                        column: x => x.LocationsId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AllocationWarehouseLocation",
                columns: table => new
                {
                    LocationsId = table.Column<int>(type: "int", nullable: false),
                    AllocationWarehousesId = table.Column<int>(type: "int", nullable: false),
                    AllocationWarehousesPK = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllocationWarehouseLocation", x => new { x.LocationsId, x.AllocationWarehousesId, x.AllocationWarehousesPK });
                    table.ForeignKey(
                        name: "FK_AllocationWarehouseLocation_AllocationWarehouses_AllocationWarehousesId_AllocationWarehousesPK",
                        columns: x => new { x.AllocationWarehousesId, x.AllocationWarehousesPK },
                        principalTable: "AllocationWarehouses",
                        principalColumns: new[] { "Id", "PK" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllocationWarehouseLocation_Locations_LocationsId",
                        column: x => x.LocationsId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationShippingWarehouse",
                columns: table => new
                {
                    LocationsId = table.Column<int>(type: "int", nullable: false),
                    ShippingWarehousesId = table.Column<int>(type: "int", nullable: false),
                    ShippingWarehousesPK = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationShippingWarehouse", x => new { x.LocationsId, x.ShippingWarehousesId, x.ShippingWarehousesPK });
                    table.ForeignKey(
                        name: "FK_LocationShippingWarehouse_Locations_LocationsId",
                        column: x => x.LocationsId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationShippingWarehouse_ShippingWarehouses_ShippingWarehousesId_ShippingWarehousesPK",
                        columns: x => new { x.ShippingWarehousesId, x.ShippingWarehousesPK },
                        principalTable: "ShippingWarehouses",
                        principalColumns: new[] { "Id", "PK" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryAK = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StockAK = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InventoryAK = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductItemAK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseItemAK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PalletAK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MesureAK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatchAK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductVendorAK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPackageAK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllocationWarehouseId = table.Column<int>(type: "int", nullable: true),
                    AllocationWarehousePK = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CollectProductsId = table.Column<int>(type: "int", nullable: true),
                    GoodsWarehouseId = table.Column<int>(type: "int", nullable: true),
                    GoodsWarehousePK = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ShippingWarehouseId = table.Column<int>(type: "int", nullable: true),
                    ShippingWarehousePK = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => new { x.Id, x.PK });
                    table.UniqueConstraint("AK_Products_PK", x => x.PK);
                    table.ForeignKey(
                        name: "FK_Products_AllocationWarehouses_AllocationWarehouseId_AllocationWarehousePK",
                        columns: x => new { x.AllocationWarehouseId, x.AllocationWarehousePK },
                        principalTable: "AllocationWarehouses",
                        principalColumns: new[] { "Id", "PK" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryAK",
                        column: x => x.CategoryAK,
                        principalTable: "Categories",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_CollectProducts_CollectProductsId",
                        column: x => x.CollectProductsId,
                        principalTable: "CollectProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_GoodsWarehouses_GoodsWarehouseId_GoodsWarehousePK",
                        columns: x => new { x.GoodsWarehouseId, x.GoodsWarehousePK },
                        principalTable: "GoodsWarehouses",
                        principalColumns: new[] { "Id", "PK" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Inventories_InventoryAK",
                        column: x => x.InventoryAK,
                        principalTable: "Inventories",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ShippingWarehouses_ShippingWarehouseId_ShippingWarehousePK",
                        columns: x => new { x.ShippingWarehouseId, x.ShippingWarehousePK },
                        principalTable: "ShippingWarehouses",
                        principalColumns: new[] { "Id", "PK" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Stocks_StockAK",
                        column: x => x.StockAK,
                        principalTable: "Stocks",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductMesures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnitBuyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitSellPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantityPerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MesureID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMesures", x => new { x.Id, x.PK });
                    table.ForeignKey(
                        name: "FK_ProductMesures_Mesures_MesureID",
                        column: x => x.MesureID,
                        principalTable: "Mesures",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductMesures_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PackageID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductItemID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseItemID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPackages", x => new { x.Id, x.PK });
                    table.UniqueConstraint("AK_ProductPackages_PK", x => x.PK);
                    table.ForeignKey(
                        name: "FK_ProductPackages_Packages_PackageID",
                        column: x => x.PackageID,
                        principalTable: "Packages",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductPackages_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyPricePerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellPricePerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Metrial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatchId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MesureId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllocationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllocationId1 = table.Column<int>(type: "int", nullable: true),
                    CollectProductItemId = table.Column<int>(type: "int", nullable: true),
                    ProductPackagesId = table.Column<int>(type: "int", nullable: true),
                    ProductPackagesPK = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItems", x => new { x.Id, x.PK });
                    table.UniqueConstraint("AK_ProductItems_PK", x => x.PK);
                    table.ForeignKey(
                        name: "FK_ProductItems_Allocations_AllocationId1",
                        column: x => x.AllocationId1,
                        principalTable: "Allocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductItems_CollectProductItems_CollectProductItemId",
                        column: x => x.CollectProductItemId,
                        principalTable: "CollectProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductItems_ProductPackages_ProductPackagesId_ProductPackagesPK",
                        columns: x => new { x.ProductPackagesId, x.ProductPackagesPK },
                        principalTable: "ProductPackages",
                        principalColumns: new[] { "Id", "PK" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Batches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InventoryId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StockId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductSupplierID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PalletID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseItemID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductItemId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AllocationWarehouseId = table.Column<int>(type: "int", nullable: true),
                    AllocationWarehousePK = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GoodsWarehouseId = table.Column<int>(type: "int", nullable: true),
                    GoodsWarehousePK = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ShippingWarehouseId = table.Column<int>(type: "int", nullable: true),
                    ShippingWarehousePK = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => new { x.Id, x.PK });
                    table.UniqueConstraint("AK_Batches_PK", x => x.PK);
                    table.ForeignKey(
                        name: "FK_Batches_AllocationWarehouses_AllocationWarehouseId_AllocationWarehousePK",
                        columns: x => new { x.AllocationWarehouseId, x.AllocationWarehousePK },
                        principalTable: "AllocationWarehouses",
                        principalColumns: new[] { "Id", "PK" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Batches_GoodsWarehouses_GoodsWarehouseId_GoodsWarehousePK",
                        columns: x => new { x.GoodsWarehouseId, x.GoodsWarehousePK },
                        principalTable: "GoodsWarehouses",
                        principalColumns: new[] { "Id", "PK" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Batches_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Batches_ProductItems_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItems",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Batches_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Batches_ShippingWarehouses_ShippingWarehouseId_ShippingWarehousePK",
                        columns: x => new { x.ShippingWarehouseId, x.ShippingWarehousePK },
                        principalTable: "ShippingWarehouses",
                        principalColumns: new[] { "Id", "PK" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Batches_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MesureProductItem",
                columns: table => new
                {
                    ProductItemsId = table.Column<int>(type: "int", nullable: false),
                    ProductItemsPK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UnitOfMesureId = table.Column<int>(type: "int", nullable: false),
                    UnitOfMesurePK = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MesureProductItem", x => new { x.ProductItemsId, x.ProductItemsPK, x.UnitOfMesureId, x.UnitOfMesurePK });
                    table.ForeignKey(
                        name: "FK_MesureProductItem_Mesures_UnitOfMesureId_UnitOfMesurePK",
                        columns: x => new { x.UnitOfMesureId, x.UnitOfMesurePK },
                        principalTable: "Mesures",
                        principalColumns: new[] { "Id", "PK" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MesureProductItem_ProductItems_ProductItemsId_ProductItemsPK",
                        columns: x => new { x.ProductItemsId, x.ProductItemsPK },
                        principalTable: "ProductItems",
                        principalColumns: new[] { "Id", "PK" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductItem",
                columns: table => new
                {
                    ProductItemsId = table.Column<int>(type: "int", nullable: false),
                    ProductItemsPK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    ProductsPK = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductItem", x => new { x.ProductItemsId, x.ProductItemsPK, x.ProductsId, x.ProductsPK });
                    table.ForeignKey(
                        name: "FK_ProductProductItem_ProductItems_ProductItemsId_ProductItemsPK",
                        columns: x => new { x.ProductItemsId, x.ProductItemsPK },
                        principalTable: "ProductItems",
                        principalColumns: new[] { "Id", "PK" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductItem_Products_ProductsId_ProductsPK",
                        columns: x => new { x.ProductsId, x.ProductsPK },
                        principalTable: "Products",
                        principalColumns: new[] { "Id", "PK" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierPallet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PalletNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PalletCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BatcID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPallets_Batches_BatcID",
                        column: x => x.BatcID,
                        principalTable: "Batches",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductPallets_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductVendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VendorID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BatchId = table.Column<int>(type: "int", nullable: true),
                    BatchPK = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVendors", x => new { x.Id, x.PK });
                    table.ForeignKey(
                        name: "FK_ProductVendors_Batches_BatchId_BatchPK",
                        columns: x => new { x.BatchId, x.BatchPK },
                        principalTable: "Batches",
                        principalColumns: new[] { "Id", "PK" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductVendors_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductVendors_Vendors_VendorID",
                        column: x => x.VendorID,
                        principalTable: "Vendors",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BatchID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LocationID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductPackageID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EmployeeID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductMesureId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllocationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AllocationWarehouseId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GoodsWarehouseId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ShippingWarhouseId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductMesuresId = table.Column<int>(type: "int", nullable: true),
                    ProductMesuresPK = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CollectItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseItems", x => new { x.Id, x.PK });
                    table.ForeignKey(
                        name: "FK_WarehouseItems_Allocations_AllocationId",
                        column: x => x.AllocationId,
                        principalTable: "Allocations",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseItems_AllocationWarehouses_AllocationWarehouseId",
                        column: x => x.AllocationWarehouseId,
                        principalTable: "AllocationWarehouses",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseItems_Batches_BatchID",
                        column: x => x.BatchID,
                        principalTable: "Batches",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseItems_CollectItems_CollectItemId",
                        column: x => x.CollectItemId,
                        principalTable: "CollectItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseItems_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseItems_GoodsWarehouses_GoodsWarehouseId",
                        column: x => x.GoodsWarehouseId,
                        principalTable: "GoodsWarehouses",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseItems_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseItems_ProductMesures_ProductMesuresId_ProductMesuresPK",
                        columns: x => new { x.ProductMesuresId, x.ProductMesuresPK },
                        principalTable: "ProductMesures",
                        principalColumns: new[] { "Id", "PK" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseItems_ProductPackages_ProductPackageID",
                        column: x => x.ProductPackageID,
                        principalTable: "ProductPackages",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseItems_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseItems_ShippingWarehouses_ShippingWarhouseId",
                        column: x => x.ShippingWarhouseId,
                        principalTable: "ShippingWarehouses",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allocations_OrderID",
                table: "Allocations",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_AllocationWarehouseLocation_AllocationWarehousesId_AllocationWarehousesPK",
                table: "AllocationWarehouseLocation",
                columns: new[] { "AllocationWarehousesId", "AllocationWarehousesPK" });

            migrationBuilder.CreateIndex(
                name: "IX_AllocationWarehouses_Id",
                table: "AllocationWarehouses",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AllocationWarehouses_InventoryId_InventoryPK",
                table: "AllocationWarehouses",
                columns: new[] { "InventoryId", "InventoryPK" });

            migrationBuilder.CreateIndex(
                name: "IX_AllocationWarehouses_PK",
                table: "AllocationWarehouses",
                column: "PK",
                unique: true,
                filter: "[PK] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AllocationWarehouses_StockId_StockPK",
                table: "AllocationWarehouses",
                columns: new[] { "StockId", "StockPK" });

            migrationBuilder.CreateIndex(
                name: "IX_Batches_AllocationWarehouseId_AllocationWarehousePK",
                table: "Batches",
                columns: new[] { "AllocationWarehouseId", "AllocationWarehousePK" });

            migrationBuilder.CreateIndex(
                name: "IX_Batches_GoodsWarehouseId_GoodsWarehousePK",
                table: "Batches",
                columns: new[] { "GoodsWarehouseId", "GoodsWarehousePK" });

            migrationBuilder.CreateIndex(
                name: "IX_Batches_Id",
                table: "Batches",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_InventoryId",
                table: "Batches",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_PK",
                table: "Batches",
                column: "PK",
                unique: true,
                filter: "[PK] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_ProductID",
                table: "Batches",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_ProductItemId",
                table: "Batches",
                column: "ProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_ShippingWarehouseId_ShippingWarehousePK",
                table: "Batches",
                columns: new[] { "ShippingWarehouseId", "ShippingWarehousePK" });

            migrationBuilder.CreateIndex(
                name: "IX_Batches_StockId",
                table: "Batches",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Id",
                table: "Categories",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_PK",
                table: "Categories",
                column: "PK",
                unique: true,
                filter: "[PK] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsWarehouseLocation_GoodsWarehousesId_GoodsWarehousesPK",
                table: "GoodsWarehouseLocation",
                columns: new[] { "GoodsWarehousesId", "GoodsWarehousesPK" });

            migrationBuilder.CreateIndex(
                name: "IX_GoodsWarehouses_Id",
                table: "GoodsWarehouses",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsWarehouses_InventoryId_InventoryPK",
                table: "GoodsWarehouses",
                columns: new[] { "InventoryId", "InventoryPK" });

            migrationBuilder.CreateIndex(
                name: "IX_GoodsWarehouses_PK",
                table: "GoodsWarehouses",
                column: "PK",
                unique: true,
                filter: "[PK] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_Id",
                table: "Inventories",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_PK",
                table: "Inventories",
                column: "PK",
                unique: true,
                filter: "[PK] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LocationShippingWarehouse_ShippingWarehousesId_ShippingWarehousesPK",
                table: "LocationShippingWarehouse",
                columns: new[] { "ShippingWarehousesId", "ShippingWarehousesPK" });

            migrationBuilder.CreateIndex(
                name: "IX_MesureProductItem_UnitOfMesureId_UnitOfMesurePK",
                table: "MesureProductItem",
                columns: new[] { "UnitOfMesureId", "UnitOfMesurePK" });

            migrationBuilder.CreateIndex(
                name: "IX_Mesures_Id",
                table: "Mesures",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Mesures_PK",
                table: "Mesures",
                column: "PK",
                unique: true,
                filter: "[PK] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderOrderPallet_OrdersId",
                table: "OrderOrderPallet",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_Id",
                table: "Packages",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_PK",
                table: "Packages",
                column: "PK",
                unique: true,
                filter: "[PK] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_AllocationId1",
                table: "ProductItems",
                column: "AllocationId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_CollectProductItemId",
                table: "ProductItems",
                column: "CollectProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_Id",
                table: "ProductItems",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_PK",
                table: "ProductItems",
                column: "PK",
                unique: true,
                filter: "[PK] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_ProductPackagesId_ProductPackagesPK",
                table: "ProductItems",
                columns: new[] { "ProductPackagesId", "ProductPackagesPK" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductMesures_Id",
                table: "ProductMesures",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMesures_MesureID",
                table: "ProductMesures",
                column: "MesureID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMesures_PK",
                table: "ProductMesures",
                column: "PK",
                unique: true,
                filter: "[PK] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMesures_ProductID",
                table: "ProductMesures",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPackages_Id",
                table: "ProductPackages",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPackages_PackageID",
                table: "ProductPackages",
                column: "PackageID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPackages_PK",
                table: "ProductPackages",
                column: "PK",
                unique: true,
                filter: "[PK] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPackages_ProductID",
                table: "ProductPackages",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPallets_BatcID",
                table: "ProductPallets",
                column: "BatcID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPallets_ProductID",
                table: "ProductPallets",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductItem_ProductsId_ProductsPK",
                table: "ProductProductItem",
                columns: new[] { "ProductsId", "ProductsPK" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_AllocationWarehouseId_AllocationWarehousePK",
                table: "Products",
                columns: new[] { "AllocationWarehouseId", "AllocationWarehousePK" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryAK",
                table: "Products",
                column: "CategoryAK");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CollectProductsId",
                table: "Products",
                column: "CollectProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_GoodsWarehouseId_GoodsWarehousePK",
                table: "Products",
                columns: new[] { "GoodsWarehouseId", "GoodsWarehousePK" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Id",
                table: "Products",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_InventoryAK",
                table: "Products",
                column: "InventoryAK");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PK",
                table: "Products",
                column: "PK",
                unique: true,
                filter: "[PK] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShippingWarehouseId_ShippingWarehousePK",
                table: "Products",
                columns: new[] { "ShippingWarehouseId", "ShippingWarehousePK" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_StockAK",
                table: "Products",
                column: "StockAK");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVendors_BatchId_BatchPK",
                table: "ProductVendors",
                columns: new[] { "BatchId", "BatchPK" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductVendors_Id",
                table: "ProductVendors",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVendors_PK",
                table: "ProductVendors",
                column: "PK",
                unique: true,
                filter: "[PK] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVendors_ProductID",
                table: "ProductVendors",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVendors_VendorID",
                table: "ProductVendors",
                column: "VendorID");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingWarehouses_Id",
                table: "ShippingWarehouses",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingWarehouses_PK",
                table: "ShippingWarehouses",
                column: "PK",
                unique: true,
                filter: "[PK] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingWarehouses_StockId_StockPK",
                table: "ShippingWarehouses",
                columns: new[] { "StockId", "StockPK" });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Id",
                table: "Stocks",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_PK",
                table: "Stocks",
                column: "PK",
                unique: true,
                filter: "[PK] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryId",
                table: "SubCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_Id",
                table: "SubCategory",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_PK",
                table: "SubCategory",
                column: "PK",
                unique: true,
                filter: "[PK] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseItems_AllocationId",
                table: "WarehouseItems",
                column: "AllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseItems_AllocationWarehouseId",
                table: "WarehouseItems",
                column: "AllocationWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseItems_BatchID",
                table: "WarehouseItems",
                column: "BatchID");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseItems_CollectItemId",
                table: "WarehouseItems",
                column: "CollectItemId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseItems_EmployeeID",
                table: "WarehouseItems",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseItems_GoodsWarehouseId",
                table: "WarehouseItems",
                column: "GoodsWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseItems_Id",
                table: "WarehouseItems",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseItems_LocationID",
                table: "WarehouseItems",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseItems_PK",
                table: "WarehouseItems",
                column: "PK",
                unique: true,
                filter: "[PK] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseItems_ProductID",
                table: "WarehouseItems",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseItems_ProductMesuresId_ProductMesuresPK",
                table: "WarehouseItems",
                columns: new[] { "ProductMesuresId", "ProductMesuresPK" });

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseItems_ProductPackageID",
                table: "WarehouseItems",
                column: "ProductPackageID");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseItems_ShippingWarhouseId",
                table: "WarehouseItems",
                column: "ShippingWarhouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllocationWarehouseLocation");

            migrationBuilder.DropTable(
                name: "Audits");

            migrationBuilder.DropTable(
                name: "GoodsWarehouseLocation");

            migrationBuilder.DropTable(
                name: "LocationShippingWarehouse");

            migrationBuilder.DropTable(
                name: "MesureProductItem");

            migrationBuilder.DropTable(
                name: "OrderOrderPallet");

            migrationBuilder.DropTable(
                name: "ProductPallets");

            migrationBuilder.DropTable(
                name: "ProductProductItem");

            migrationBuilder.DropTable(
                name: "ProductVendors");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "WarehouseItems");

            migrationBuilder.DropTable(
                name: "OrderPallet");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "Batches");

            migrationBuilder.DropTable(
                name: "CollectItems");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "ProductMesures");

            migrationBuilder.DropTable(
                name: "ProductItems");

            migrationBuilder.DropTable(
                name: "Mesures");

            migrationBuilder.DropTable(
                name: "Allocations");

            migrationBuilder.DropTable(
                name: "CollectProductItems");

            migrationBuilder.DropTable(
                name: "ProductPackages");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AllocationWarehouses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CollectProducts");

            migrationBuilder.DropTable(
                name: "GoodsWarehouses");

            migrationBuilder.DropTable(
                name: "ShippingWarehouses");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
