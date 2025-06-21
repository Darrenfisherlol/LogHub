using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LogHubStart.Migrations
{
    /// <inheritdoc />
    public partial class migrationOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryName = table.Column<string>(type: "text", nullable: false),
                    CategoryDescription = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdminAccess = table.Column<bool>(type: "boolean", nullable: false),
                    ManagerAccess = table.Column<bool>(type: "boolean", nullable: false),
                    WorkerAccess = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SupplierName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WarehouseName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Address = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    State = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Country = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    ZipCode = table.Column<int>(type: "integer", nullable: false),
                    OwnerName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Phone = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.WarehouseId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    SKU = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    First = table.Column<string>(type: "text", nullable: false),
                    Last = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: true),
                    SupplierId = table.Column<int>(type: "integer", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Tax = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_Invoices_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId");
                });

            migrationBuilder.CreateTable(
                name: "WarehouseSections",
                columns: table => new
                {
                    WarehouseSectionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WarehouseId = table.Column<int>(type: "integer", nullable: false),
                    Desc = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseSections", x => x.WarehouseSectionId);
                    table.ForeignKey(
                        name: "FK_WarehouseSections_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvoiceId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BinStorages",
                columns: table => new
                {
                    BinStorageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WarehouseSectionsId = table.Column<int>(type: "integer", nullable: false),
                    Row = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinStorages", x => x.BinStorageId);
                    table.ForeignKey(
                        name: "FK_BinStorages_WarehouseSections_WarehouseSectionsId",
                        column: x => x.WarehouseSectionsId,
                        principalTable: "WarehouseSections",
                        principalColumn: "WarehouseSectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Islands",
                columns: table => new
                {
                    IslandId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WarehouseSectionsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Islands", x => x.IslandId);
                    table.ForeignKey(
                        name: "FK_Islands_WarehouseSections_WarehouseSectionsId",
                        column: x => x.WarehouseSectionsId,
                        principalTable: "WarehouseSections",
                        principalColumn: "WarehouseSectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StraightLines",
                columns: table => new
                {
                    StraightLineID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WarehouseSectionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StraightLines", x => x.StraightLineID);
                    table.ForeignKey(
                        name: "FK_StraightLines_WarehouseSections_WarehouseSectionId",
                        column: x => x.WarehouseSectionId,
                        principalTable: "WarehouseSections",
                        principalColumn: "WarehouseSectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    OrderProductId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bins",
                columns: table => new
                {
                    BinId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BinStorageId = table.Column<int>(type: "integer", nullable: false),
                    BinCapacity = table.Column<double>(type: "double precision", nullable: false),
                    Height = table.Column<double>(type: "double precision", nullable: false),
                    Width = table.Column<double>(type: "double precision", nullable: false),
                    Length = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bins", x => x.BinId);
                    table.ForeignKey(
                        name: "FK_Bins_BinStorages_BinStorageId",
                        column: x => x.BinStorageId,
                        principalTable: "BinStorages",
                        principalColumn: "BinStorageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IslandPositions",
                columns: table => new
                {
                    IslandPositionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IslandId = table.Column<int>(type: "integer", nullable: false),
                    IslandCapacity = table.Column<double>(type: "double precision", nullable: false),
                    Height = table.Column<double>(type: "double precision", nullable: false),
                    Width = table.Column<double>(type: "double precision", nullable: false),
                    Length = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IslandPositions", x => x.IslandPositionId);
                    table.ForeignKey(
                        name: "FK_IslandPositions_Islands_IslandId",
                        column: x => x.IslandId,
                        principalTable: "Islands",
                        principalColumn: "IslandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aisles",
                columns: table => new
                {
                    AisleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StraightLineId = table.Column<int>(type: "integer", nullable: false),
                    AisleName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aisles", x => x.AisleId);
                    table.ForeignKey(
                        name: "FK_Aisles_StraightLines_StraightLineId",
                        column: x => x.StraightLineId,
                        principalTable: "StraightLines",
                        principalColumn: "StraightLineID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AisleSections",
                columns: table => new
                {
                    AisleSectionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AisleId = table.Column<int>(type: "integer", nullable: false),
                    SectionName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AisleSections", x => x.AisleSectionId);
                    table.ForeignKey(
                        name: "FK_AisleSections_Aisles_AisleId",
                        column: x => x.AisleId,
                        principalTable: "Aisles",
                        principalColumn: "AisleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AisleSectionPositions",
                columns: table => new
                {
                    AisleSectionPositionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AisleSectionId = table.Column<int>(type: "integer", nullable: false),
                    PositionCapacity = table.Column<double>(type: "double precision", nullable: false),
                    Height = table.Column<double>(type: "double precision", nullable: false),
                    Width = table.Column<double>(type: "double precision", nullable: false),
                    Length = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AisleSectionPositions", x => x.AisleSectionPositionId);
                    table.ForeignKey(
                        name: "FK_AisleSectionPositions_AisleSections_AisleSectionId",
                        column: x => x.AisleSectionId,
                        principalTable: "AisleSections",
                        principalColumn: "AisleSectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductLocations",
                columns: table => new
                {
                    ItemLocationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IslandPositionId = table.Column<int>(type: "integer", nullable: true),
                    BinId = table.Column<int>(type: "integer", nullable: true),
                    PositionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLocations", x => x.ItemLocationId);
                    table.ForeignKey(
                        name: "FK_ProductLocations_AisleSectionPositions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "AisleSectionPositions",
                        principalColumn: "AisleSectionPositionId");
                    table.ForeignKey(
                        name: "FK_ProductLocations_Bins_BinId",
                        column: x => x.BinId,
                        principalTable: "Bins",
                        principalColumn: "BinId");
                    table.ForeignKey(
                        name: "FK_ProductLocations_IslandPositions_IslandPositionId",
                        column: x => x.IslandPositionId,
                        principalTable: "IslandPositions",
                        principalColumn: "IslandPositionId");
                });

            migrationBuilder.CreateTable(
                name: "ItemStocks",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemLocationId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemStocks", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_ItemStocks_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK_ItemStocks_ProductLocations_ItemLocationId",
                        column: x => x.ItemLocationId,
                        principalTable: "ProductLocations",
                        principalColumn: "ItemLocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemStocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryMovements",
                columns: table => new
                {
                    InventoryMovementId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    FromProductLocationId = table.Column<int>(type: "integer", nullable: false),
                    ToProductLocationId = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: true),
                    MovementDate = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    MovementByEmployeeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryMovements", x => x.InventoryMovementId);
                    table.ForeignKey(
                        name: "FK_InventoryMovements_Employees_MovementByEmployeeId",
                        column: x => x.MovementByEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryMovements_ItemStocks_ItemId",
                        column: x => x.ItemId,
                        principalTable: "ItemStocks",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryMovements_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_InventoryMovements_ProductLocations_FromProductLocationId",
                        column: x => x.FromProductLocationId,
                        principalTable: "ProductLocations",
                        principalColumn: "ItemLocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryMovements_ProductLocations_ToProductLocationId",
                        column: x => x.ToProductLocationId,
                        principalTable: "ProductLocations",
                        principalColumn: "ItemLocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aisles_StraightLineId",
                table: "Aisles",
                column: "StraightLineId");

            migrationBuilder.CreateIndex(
                name: "IX_AisleSectionPositions_AisleSectionId",
                table: "AisleSectionPositions",
                column: "AisleSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_AisleSections_AisleId",
                table: "AisleSections",
                column: "AisleId");

            migrationBuilder.CreateIndex(
                name: "IX_Bins_BinStorageId",
                table: "Bins",
                column: "BinStorageId");

            migrationBuilder.CreateIndex(
                name: "IX_BinStorages_WarehouseSectionsId",
                table: "BinStorages",
                column: "WarehouseSectionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleId",
                table: "Employees",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovements_FromProductLocationId",
                table: "InventoryMovements",
                column: "FromProductLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovements_ItemId",
                table: "InventoryMovements",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovements_MovementByEmployeeId",
                table: "InventoryMovements",
                column: "MovementByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovements_OrderId",
                table: "InventoryMovements",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovements_ToProductLocationId",
                table: "InventoryMovements",
                column: "ToProductLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_SupplierId",
                table: "Invoices",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_IslandPositions_IslandId",
                table: "IslandPositions",
                column: "IslandId");

            migrationBuilder.CreateIndex(
                name: "IX_Islands_WarehouseSectionsId",
                table: "Islands",
                column: "WarehouseSectionsId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemStocks_ItemLocationId",
                table: "ItemStocks",
                column: "ItemLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemStocks_OrderId",
                table: "ItemStocks",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemStocks_ProductId",
                table: "ItemStocks",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeId",
                table: "Orders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_InvoiceId",
                table: "Orders",
                column: "InvoiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductLocations_BinId",
                table: "ProductLocations",
                column: "BinId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLocations_IslandPositionId",
                table: "ProductLocations",
                column: "IslandPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLocations_PositionId",
                table: "ProductLocations",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StraightLines_WarehouseSectionId",
                table: "StraightLines",
                column: "WarehouseSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseSections_WarehouseId",
                table: "WarehouseSections",
                column: "WarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryMovements");

            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "ItemStocks");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductLocations");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "AisleSectionPositions");

            migrationBuilder.DropTable(
                name: "Bins");

            migrationBuilder.DropTable(
                name: "IslandPositions");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "AisleSections");

            migrationBuilder.DropTable(
                name: "BinStorages");

            migrationBuilder.DropTable(
                name: "Islands");

            migrationBuilder.DropTable(
                name: "Aisles");

            migrationBuilder.DropTable(
                name: "StraightLines");

            migrationBuilder.DropTable(
                name: "WarehouseSections");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
