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
                name: "BaseStocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsQuanityAvailable = table.Column<bool>(type: "bit", nullable: false),
                    TotalUnitsQuantity = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ProductQuantity = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    BatchQuantity = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatchID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Inventory_UnitsInStock = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnitsInOrder = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Inventory_ReorderLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnitsInStock = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ReorderLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseStocks", x => new { x.Id, x.PK });
                    table.UniqueConstraint("AK_BaseStocks_PK", x => x.PK);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                name: "Mesures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    AllocationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    WarehouseItemID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allocations", x => x.Id);
                    table.UniqueConstraint("AK_Allocations_PK", x => x.PK);
                    table.ForeignKey(
                        name: "FK_Allocations_Orders_AllocationId",
                        column: x => x.AllocationId,
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
                name: "ProductItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyPricePerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellPricePerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Metrial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatcId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mesure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllocationId = table.Column<int>(type: "int", nullable: true),
                    CollectProductItemId = table.Column<int>(type: "int", nullable: true),
                    ProductPackagesId = table.Column<int>(type: "int", nullable: true),
                    ProductPackagesPK = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItems", x => new { x.Id, x.PK });
                    table.UniqueConstraint("AK_ProductItems_PK", x => x.PK);
                    table.ForeignKey(
                        name: "FK_ProductItems_Allocations_AllocationId",
                        column: x => x.AllocationId,
                        principalTable: "Allocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductItems_CollectProductItems_CollectProductItemId",
                        column: x => x.CollectProductItemId,
                        principalTable: "CollectProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MesureProductItem",
                columns: table => new
                {
                    ProductItemsId = table.Column<int>(type: "int", nullable: false),
                    ProductItemsPK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UnitOfMeusreId = table.Column<int>(type: "int", nullable: false),
                    UnitOfMeusrePK = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MesureProductItem", x => new { x.ProductItemsId, x.ProductItemsPK, x.UnitOfMeusreId, x.UnitOfMeusrePK });
                    table.ForeignKey(
                        name: "FK_MesureProductItem_Mesures_UnitOfMeusreId_UnitOfMeusrePK",
                        columns: x => new { x.UnitOfMeusreId, x.UnitOfMeusrePK },
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
                name: "WarehouseItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PalletNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseItemID = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "Batches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StockInID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StockOutID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductSupplierID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PalletID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseItemID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductItemId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BaseWarehouseId = table.Column<int>(type: "int", nullable: true),
                    BaseWarehousePK = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => new { x.Id, x.PK });
                    table.UniqueConstraint("AK_Batches_PK", x => x.PK);
                    table.ForeignKey(
                        name: "FK_Batches_BaseStocks_StockInID",
                        column: x => x.StockInID,
                        principalTable: "BaseStocks",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Batches_BaseStocks_StockOutID",
                        column: x => x.StockOutID,
                        principalTable: "BaseStocks",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Batches_ProductItems_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItems",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StockInID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StockOutID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ItemID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PalletID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MesureID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatchID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductSupplierID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPackageID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseWarehouseId = table.Column<int>(type: "int", nullable: true),
                    BaseWarehousePK = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CollectProductsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => new { x.Id, x.PK });
                    table.UniqueConstraint("AK_Products_PK", x => x.PK);
                    table.ForeignKey(
                        name: "FK_Products_BaseStocks_StockInID",
                        column: x => x.StockInID,
                        principalTable: "BaseStocks",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_BaseStocks_StockOutID",
                        column: x => x.StockOutID,
                        principalTable: "BaseStocks",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_CollectProducts_CollectProductsId",
                        column: x => x.CollectProductsId,
                        principalTable: "CollectProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductMesures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                name: "ProductVendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WarehouseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WarehouseItemAK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationAK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductAK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatchID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllocationWarehouse_LocationId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => new { x.Id, x.PK });
                    table.UniqueConstraint("AK_Warehouses_PK", x => x.PK);
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
                    WarehouseID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseItemID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseWarehouseId = table.Column<int>(type: "int", nullable: true),
                    BaseWarehousePK = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.UniqueConstraint("AK_Locations_PK", x => x.PK);
                    table.ForeignKey(
                        name: "FK_Locations_Warehouses_BaseWarehouseId_BaseWarehousePK",
                        columns: x => new { x.BaseWarehouseId, x.BaseWarehousePK },
                        principalTable: "Warehouses",
                        principalColumns: new[] { "Id", "PK" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allocations_AllocationId",
                table: "Allocations",
                column: "AllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseStocks_Id",
                table: "BaseStocks",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BaseStocks_PK",
                table: "BaseStocks",
                column: "PK",
                unique: true,
                filter: "[PK] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_BaseWarehouseId_BaseWarehousePK",
                table: "Batches",
                columns: new[] { "BaseWarehouseId", "BaseWarehousePK" });

            migrationBuilder.CreateIndex(
                name: "IX_Batches_Id",
                table: "Batches",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

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
                name: "IX_Batches_StockInID",
                table: "Batches",
                column: "StockInID");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_StockOutID",
                table: "Batches",
                column: "StockOutID");

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
                name: "IX_Locations_BaseWarehouseId_BaseWarehousePK",
                table: "Locations",
                columns: new[] { "BaseWarehouseId", "BaseWarehousePK" });

            migrationBuilder.CreateIndex(
                name: "IX_MesureProductItem_UnitOfMeusreId_UnitOfMeusrePK",
                table: "MesureProductItem",
                columns: new[] { "UnitOfMeusreId", "UnitOfMeusrePK" });

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
                name: "IX_ProductItems_AllocationId",
                table: "ProductItems",
                column: "AllocationId");

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
                name: "IX_Products_BaseWarehouseId_BaseWarehousePK",
                table: "Products",
                columns: new[] { "BaseWarehouseId", "BaseWarehousePK" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CollectProductsId",
                table: "Products",
                column: "CollectProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Id",
                table: "Products",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PK",
                table: "Products",
                column: "PK",
                unique: true,
                filter: "[PK] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StockInID",
                table: "Products",
                column: "StockInID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StockOutID",
                table: "Products",
                column: "StockOutID");

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

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_AllocationWarehouse_LocationId",
                table: "Warehouses",
                column: "AllocationWarehouse_LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_Id",
                table: "Warehouses",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_LocationId",
                table: "Warehouses",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_PK",
                table: "Warehouses",
                column: "PK",
                unique: true,
                filter: "[PK] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_ProductPackages_ProductPackagesId_ProductPackagesPK",
                table: "ProductItems",
                columns: new[] { "ProductPackagesId", "ProductPackagesPK" },
                principalTable: "ProductPackages",
                principalColumns: new[] { "Id", "PK" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseItems_Batches_BatchID",
                table: "WarehouseItems",
                column: "BatchID",
                principalTable: "Batches",
                principalColumn: "PK",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseItems_Locations_LocationID",
                table: "WarehouseItems",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "PK",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseItems_ProductMesures_ProductMesuresId_ProductMesuresPK",
                table: "WarehouseItems",
                columns: new[] { "ProductMesuresId", "ProductMesuresPK" },
                principalTable: "ProductMesures",
                principalColumns: new[] { "Id", "PK" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseItems_ProductPackages_ProductPackageID",
                table: "WarehouseItems",
                column: "ProductPackageID",
                principalTable: "ProductPackages",
                principalColumn: "PK",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseItems_Products_ProductID",
                table: "WarehouseItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "PK",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseItems_Warehouses_AllocationWarehouseId",
                table: "WarehouseItems",
                column: "AllocationWarehouseId",
                principalTable: "Warehouses",
                principalColumn: "PK",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseItems_Warehouses_GoodsWarehouseId",
                table: "WarehouseItems",
                column: "GoodsWarehouseId",
                principalTable: "Warehouses",
                principalColumn: "PK",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseItems_Warehouses_ShippingWarhouseId",
                table: "WarehouseItems",
                column: "ShippingWarhouseId",
                principalTable: "Warehouses",
                principalColumn: "PK",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Products_ProductID",
                table: "Batches",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "PK",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Warehouses_BaseWarehouseId_BaseWarehousePK",
                table: "Batches",
                columns: new[] { "BaseWarehouseId", "BaseWarehousePK" },
                principalTable: "Warehouses",
                principalColumns: new[] { "Id", "PK" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Warehouses_BaseWarehouseId_BaseWarehousePK",
                table: "Products",
                columns: new[] { "BaseWarehouseId", "BaseWarehousePK" },
                principalTable: "Warehouses",
                principalColumns: new[] { "Id", "PK" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Locations_AllocationWarehouse_LocationId",
                table: "Warehouses",
                column: "AllocationWarehouse_LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Locations_LocationId",
                table: "Warehouses",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Warehouses_BaseWarehouseId_BaseWarehousePK",
                table: "Locations");

            migrationBuilder.DropTable(
                name: "Audits");

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
                name: "BaseStocks");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CollectProducts");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
