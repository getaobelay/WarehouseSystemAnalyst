using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseSystemAnalyst.Data.Migrations
{
    public partial class initial_db_creation : Migration
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCategoryId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatchId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitsInInventory = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitsInOrder = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReorderLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GoodsWarehousesId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllocationWarehouseId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_Mesures", x => x.Id);
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPackageId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                    table.UniqueConstraint("AK_Packages_PK", x => x.PK);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatchId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitsInStock = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReorderLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AllocationWarehouseId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingWarehousesId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_SubCategory", x => x.Id);
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    InventoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsWarehouses", x => x.Id);
                    table.UniqueConstraint("AK_GoodsWarehouses_PK", x => x.PK);
                    table.ForeignKey(
                        name: "FK_GoodsWarehouses_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    StockId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllocationWarehouses", x => x.Id);
                    table.UniqueConstraint("AK_AllocationWarehouses_PK", x => x.PK);
                    table.ForeignKey(
                        name: "FK_AllocationWarehouses_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AllocationWarehouses_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShippingWarehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    StockId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingWarehouses", x => x.Id);
                    table.UniqueConstraint("AK_ShippingWarehouses_PK", x => x.PK);
                    table.ForeignKey(
                        name: "FK_ShippingWarehouses_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GoodsWarehouseLocation",
                columns: table => new
                {
                    GoodsWarehousesId = table.Column<int>(type: "int", nullable: false),
                    LocationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsWarehouseLocation", x => new { x.GoodsWarehousesId, x.LocationsId });
                    table.ForeignKey(
                        name: "FK_GoodsWarehouseLocation_GoodsWarehouses_GoodsWarehousesId",
                        column: x => x.GoodsWarehousesId,
                        principalTable: "GoodsWarehouses",
                        principalColumn: "Id",
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
                    AllocationWarehousesId = table.Column<int>(type: "int", nullable: false),
                    LocationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllocationWarehouseLocation", x => new { x.AllocationWarehousesId, x.LocationsId });
                    table.ForeignKey(
                        name: "FK_AllocationWarehouseLocation_AllocationWarehouses_AllocationWarehousesId",
                        column: x => x.AllocationWarehousesId,
                        principalTable: "AllocationWarehouses",
                        principalColumn: "Id",
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
                    ShippingWarehousesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationShippingWarehouse", x => new { x.LocationsId, x.ShippingWarehousesId });
                    table.ForeignKey(
                        name: "FK_LocationShippingWarehouse_Locations_LocationsId",
                        column: x => x.LocationsId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationShippingWarehouse_ShippingWarehouses_ShippingWarehousesId",
                        column: x => x.ShippingWarehousesId,
                        principalTable: "ShippingWarehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StockId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InventoryId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductItemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseItemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PalletId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MesureId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatchId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductVendorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPackageId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllocationWarehouseId = table.Column<int>(type: "int", nullable: true),
                    CollectProductsId = table.Column<int>(type: "int", nullable: true),
                    GoodsWarehouseId = table.Column<int>(type: "int", nullable: true),
                    ShippingWarehouseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.UniqueConstraint("AK_Products_PK", x => x.PK);
                    table.ForeignKey(
                        name: "FK_Products_AllocationWarehouses_AllocationWarehouseId",
                        column: x => x.AllocationWarehouseId,
                        principalTable: "AllocationWarehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
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
                        name: "FK_Products_GoodsWarehouses_GoodsWarehouseId",
                        column: x => x.GoodsWarehouseId,
                        principalTable: "GoodsWarehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ShippingWarehouses_ShippingWarehouseId",
                        column: x => x.ShippingWarehouseId,
                        principalTable: "ShippingWarehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductMesures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnitBuyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitSellPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantityPerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MesureId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMesures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductMesures_Mesures_MesureId",
                        column: x => x.MesureId,
                        principalTable: "Mesures",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductMesures_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PackageId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductItemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseItemId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPackages", x => x.Id);
                    table.UniqueConstraint("AK_ProductPackages_PK", x => x.PK);
                    table.ForeignKey(
                        name: "FK_ProductPackages_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductPackages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    ProductPackagesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItems", x => x.Id);
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
                        name: "FK_ProductItems_ProductPackages_ProductPackagesId",
                        column: x => x.ProductPackagesId,
                        principalTable: "ProductPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Batches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InventoryId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StockId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductSupplierId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PalletId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseItemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductItemId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AllocationWarehouseId = table.Column<int>(type: "int", nullable: true),
                    GoodsWarehouseId = table.Column<int>(type: "int", nullable: true),
                    ShippingWarehouseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => x.Id);
                    table.UniqueConstraint("AK_Batches_PK", x => x.PK);
                    table.ForeignKey(
                        name: "FK_Batches_AllocationWarehouses_AllocationWarehouseId",
                        column: x => x.AllocationWarehouseId,
                        principalTable: "AllocationWarehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Batches_GoodsWarehouses_GoodsWarehouseId",
                        column: x => x.GoodsWarehouseId,
                        principalTable: "GoodsWarehouses",
                        principalColumn: "Id",
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
                        name: "FK_Batches_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Batches_ShippingWarehouses_ShippingWarehouseId",
                        column: x => x.ShippingWarehouseId,
                        principalTable: "ShippingWarehouses",
                        principalColumn: "Id",
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
                    UnitOfMesureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MesureProductItem", x => new { x.ProductItemsId, x.UnitOfMesureId });
                    table.ForeignKey(
                        name: "FK_MesureProductItem_Mesures_UnitOfMesureId",
                        column: x => x.UnitOfMesureId,
                        principalTable: "Mesures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MesureProductItem_ProductItems_ProductItemsId",
                        column: x => x.ProductItemsId,
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductItem",
                columns: table => new
                {
                    ProductItemsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductItem", x => new { x.ProductItemsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ProductProductItem_ProductItems_ProductItemsId",
                        column: x => x.ProductItemsId,
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductItem_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
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
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BatchId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPallets_Batches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batches",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductPallets_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductVendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VendorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BatchId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVendors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVendors_Batches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductVendors_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductVendors_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    CollectItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseItems", x => x.Id);
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
                        name: "FK_WarehouseItems_ProductMesures_ProductMesuresId",
                        column: x => x.ProductMesuresId,
                        principalTable: "ProductMesures",
                        principalColumn: "Id",
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
                name: "IX_AllocationWarehouseLocation_LocationsId",
                table: "AllocationWarehouseLocation",
                column: "LocationsId");

            migrationBuilder.CreateIndex(
                name: "IX_AllocationWarehouses_Id",
                table: "AllocationWarehouses",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AllocationWarehouses_InventoryId",
                table: "AllocationWarehouses",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AllocationWarehouses_PK",
                table: "AllocationWarehouses",
                column: "PK",
                unique: true,
                filter: "[PK] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AllocationWarehouses_StockId",
                table: "AllocationWarehouses",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_AllocationWarehouseId",
                table: "Batches",
                column: "AllocationWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_GoodsWarehouseId",
                table: "Batches",
                column: "GoodsWarehouseId");

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
                name: "IX_Batches_ProductId",
                table: "Batches",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_ProductItemId",
                table: "Batches",
                column: "ProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_ShippingWarehouseId",
                table: "Batches",
                column: "ShippingWarehouseId");

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
                name: "IX_GoodsWarehouseLocation_LocationsId",
                table: "GoodsWarehouseLocation",
                column: "LocationsId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsWarehouses_Id",
                table: "GoodsWarehouses",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsWarehouses_InventoryId",
                table: "GoodsWarehouses",
                column: "InventoryId");

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
                name: "IX_LocationShippingWarehouse_ShippingWarehousesId",
                table: "LocationShippingWarehouse",
                column: "ShippingWarehousesId");

            migrationBuilder.CreateIndex(
                name: "IX_MesureProductItem_UnitOfMesureId",
                table: "MesureProductItem",
                column: "UnitOfMesureId");

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
                name: "IX_ProductItems_ProductPackagesId",
                table: "ProductItems",
                column: "ProductPackagesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMesures_Id",
                table: "ProductMesures",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMesures_MesureId",
                table: "ProductMesures",
                column: "MesureId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMesures_PK",
                table: "ProductMesures",
                column: "PK",
                unique: true,
                filter: "[PK] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMesures_ProductId",
                table: "ProductMesures",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPackages_Id",
                table: "ProductPackages",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPackages_PackageId",
                table: "ProductPackages",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPackages_PK",
                table: "ProductPackages",
                column: "PK",
                unique: true,
                filter: "[PK] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPackages_ProductId",
                table: "ProductPackages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPallets_BatchId",
                table: "ProductPallets",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPallets_ProductId",
                table: "ProductPallets",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductItem_ProductsId",
                table: "ProductProductItem",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_AllocationWarehouseId",
                table: "Products",
                column: "AllocationWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CollectProductsId",
                table: "Products",
                column: "CollectProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_GoodsWarehouseId",
                table: "Products",
                column: "GoodsWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Id",
                table: "Products",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_InventoryId",
                table: "Products",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PK",
                table: "Products",
                column: "PK",
                unique: true,
                filter: "[PK] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShippingWarehouseId",
                table: "Products",
                column: "ShippingWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StockId",
                table: "Products",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVendors_BatchId",
                table: "ProductVendors",
                column: "BatchId");

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
                name: "IX_ProductVendors_ProductId",
                table: "ProductVendors",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVendors_VendorId",
                table: "ProductVendors",
                column: "VendorId");

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
                name: "IX_ShippingWarehouses_StockId",
                table: "ShippingWarehouses",
                column: "StockId");

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
                name: "IX_WarehouseItems_ProductMesuresId",
                table: "WarehouseItems",
                column: "ProductMesuresId");

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
