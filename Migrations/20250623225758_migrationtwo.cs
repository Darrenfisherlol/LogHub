using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogHubStart.Migrations
{
    /// <inheritdoc />
    public partial class migrationtwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aisles_StraightLines_StraightLineId",
                table: "Aisles");

            migrationBuilder.DropForeignKey(
                name: "FK_AisleSectionPositions_AisleSections_AisleSectionId",
                table: "AisleSectionPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_AisleSections_Aisles_AisleId",
                table: "AisleSections");

            migrationBuilder.DropForeignKey(
                name: "FK_Bins_BinStorages_BinStorageId",
                table: "Bins");

            migrationBuilder.DropForeignKey(
                name: "FK_BinStorages_WarehouseSections_WarehouseSectionsId",
                table: "BinStorages");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Roles_RoleId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMovements_Employees_MovementByEmployeeId",
                table: "InventoryMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMovements_ItemStocks_ItemId",
                table: "InventoryMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMovements_Orders_OrderId",
                table: "InventoryMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMovements_ProductLocations_FromProductLocationId",
                table: "InventoryMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMovements_ProductLocations_ToProductLocationId",
                table: "InventoryMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Customers_CustomerId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Suppliers_SupplierId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_IslandPositions_Islands_IslandId",
                table: "IslandPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_Islands_WarehouseSections_WarehouseSectionsId",
                table: "Islands");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemStocks_Orders_OrderId",
                table: "ItemStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemStocks_ProductLocations_ItemLocationId",
                table: "ItemStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemStocks_Products_ProductId",
                table: "ItemStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Products_ProductId",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Employees_EmployeeId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Invoices_InvoiceId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLocations_AisleSectionPositions_PositionId",
                table: "ProductLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLocations_Bins_BinId",
                table: "ProductLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLocations_IslandPositions_IslandPositionId",
                table: "ProductLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_StraightLines_WarehouseSections_WarehouseSectionId",
                table: "StraightLines");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseSections_Warehouses_WarehouseId",
                table: "WarehouseSections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WarehouseSections",
                table: "WarehouseSections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouses",
                table: "Warehouses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StraightLines",
                table: "StraightLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductLocations",
                table: "ProductLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemStocks",
                table: "ItemStocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Islands",
                table: "Islands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IslandPositions",
                table: "IslandPositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryMovements",
                table: "InventoryMovements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BinStorages",
                table: "BinStorages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bins",
                table: "Bins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AisleSections",
                table: "AisleSections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AisleSectionPositions",
                table: "AisleSectionPositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aisles",
                table: "Aisles");

            migrationBuilder.RenameTable(
                name: "WarehouseSections",
                newName: "WarehouseSection");

            migrationBuilder.RenameTable(
                name: "Warehouses",
                newName: "Warehouse");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "Supplier");

            migrationBuilder.RenameTable(
                name: "StraightLines",
                newName: "StraightLine");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "ProductLocations",
                newName: "ProductLocation");

            migrationBuilder.RenameTable(
                name: "ProductCategories",
                newName: "ProductCategorie");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "OrderProducts",
                newName: "OrderProduct");

            migrationBuilder.RenameTable(
                name: "ItemStocks",
                newName: "ItemStock");

            migrationBuilder.RenameTable(
                name: "Islands",
                newName: "Island");

            migrationBuilder.RenameTable(
                name: "IslandPositions",
                newName: "IslandPosition");

            migrationBuilder.RenameTable(
                name: "Invoices",
                newName: "Invoice");

            migrationBuilder.RenameTable(
                name: "InventoryMovements",
                newName: "InventoryMovement");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "BinStorages",
                newName: "BinStorage");

            migrationBuilder.RenameTable(
                name: "Bins",
                newName: "Bin");

            migrationBuilder.RenameTable(
                name: "AisleSections",
                newName: "AisleSection");

            migrationBuilder.RenameTable(
                name: "AisleSectionPositions",
                newName: "AisleSectionPosition");

            migrationBuilder.RenameTable(
                name: "Aisles",
                newName: "Aisle");

            migrationBuilder.RenameIndex(
                name: "IX_WarehouseSections_WarehouseId",
                table: "WarehouseSection",
                newName: "IX_WarehouseSection_WarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_StraightLines_WarehouseSectionId",
                table: "StraightLine",
                newName: "IX_StraightLine_WarehouseSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Product",
                newName: "IX_Product_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductLocations_PositionId",
                table: "ProductLocation",
                newName: "IX_ProductLocation_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductLocations_IslandPositionId",
                table: "ProductLocation",
                newName: "IX_ProductLocation_IslandPositionId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductLocations_BinId",
                table: "ProductLocation",
                newName: "IX_ProductLocation_BinId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_InvoiceId",
                table: "Order",
                newName: "IX_Order_InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_EmployeeId",
                table: "Order",
                newName: "IX_Order_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProduct",
                newName: "IX_OrderProduct_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemStocks_ProductId",
                table: "ItemStock",
                newName: "IX_ItemStock_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemStocks_OrderId",
                table: "ItemStock",
                newName: "IX_ItemStock_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemStocks_ItemLocationId",
                table: "ItemStock",
                newName: "IX_ItemStock_ItemLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Islands_WarehouseSectionsId",
                table: "Island",
                newName: "IX_Island_WarehouseSectionsId");

            migrationBuilder.RenameIndex(
                name: "IX_IslandPositions_IslandId",
                table: "IslandPosition",
                newName: "IX_IslandPosition_IslandId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_SupplierId",
                table: "Invoice",
                newName: "IX_Invoice_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoice",
                newName: "IX_Invoice_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryMovements_ToProductLocationId",
                table: "InventoryMovement",
                newName: "IX_InventoryMovement_ToProductLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryMovements_OrderId",
                table: "InventoryMovement",
                newName: "IX_InventoryMovement_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryMovements_MovementByEmployeeId",
                table: "InventoryMovement",
                newName: "IX_InventoryMovement_MovementByEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryMovements_ItemId",
                table: "InventoryMovement",
                newName: "IX_InventoryMovement_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryMovements_FromProductLocationId",
                table: "InventoryMovement",
                newName: "IX_InventoryMovement_FromProductLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_RoleId",
                table: "Employee",
                newName: "IX_Employee_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_BinStorages_WarehouseSectionsId",
                table: "BinStorage",
                newName: "IX_BinStorage_WarehouseSectionsId");

            migrationBuilder.RenameIndex(
                name: "IX_Bins_BinStorageId",
                table: "Bin",
                newName: "IX_Bin_BinStorageId");

            migrationBuilder.RenameIndex(
                name: "IX_AisleSections_AisleId",
                table: "AisleSection",
                newName: "IX_AisleSection_AisleId");

            migrationBuilder.RenameIndex(
                name: "IX_AisleSectionPositions_AisleSectionId",
                table: "AisleSectionPosition",
                newName: "IX_AisleSectionPosition_AisleSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Aisles_StraightLineId",
                table: "Aisle",
                newName: "IX_Aisle_StraightLineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WarehouseSection",
                table: "WarehouseSection",
                column: "WarehouseSectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse",
                column: "WarehouseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier",
                column: "SupplierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StraightLine",
                table: "StraightLine",
                column: "StraightLineID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductLocation",
                table: "ProductLocation",
                column: "ItemLocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategorie",
                table: "ProductCategorie",
                column: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProduct",
                table: "OrderProduct",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemStock",
                table: "ItemStock",
                column: "ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Island",
                table: "Island",
                column: "IslandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IslandPosition",
                table: "IslandPosition",
                column: "IslandPositionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice",
                column: "InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryMovement",
                table: "InventoryMovement",
                column: "InventoryMovementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BinStorage",
                table: "BinStorage",
                column: "BinStorageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bin",
                table: "Bin",
                column: "BinId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AisleSection",
                table: "AisleSection",
                column: "AisleSectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AisleSectionPosition",
                table: "AisleSectionPosition",
                column: "AisleSectionPositionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aisle",
                table: "Aisle",
                column: "AisleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aisle_StraightLine_StraightLineId",
                table: "Aisle",
                column: "StraightLineId",
                principalTable: "StraightLine",
                principalColumn: "StraightLineID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AisleSection_Aisle_AisleId",
                table: "AisleSection",
                column: "AisleId",
                principalTable: "Aisle",
                principalColumn: "AisleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AisleSectionPosition_AisleSection_AisleSectionId",
                table: "AisleSectionPosition",
                column: "AisleSectionId",
                principalTable: "AisleSection",
                principalColumn: "AisleSectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bin_BinStorage_BinStorageId",
                table: "Bin",
                column: "BinStorageId",
                principalTable: "BinStorage",
                principalColumn: "BinStorageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BinStorage_WarehouseSection_WarehouseSectionsId",
                table: "BinStorage",
                column: "WarehouseSectionsId",
                principalTable: "WarehouseSection",
                principalColumn: "WarehouseSectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Role_RoleId",
                table: "Employee",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMovement_Employee_MovementByEmployeeId",
                table: "InventoryMovement",
                column: "MovementByEmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMovement_ItemStock_ItemId",
                table: "InventoryMovement",
                column: "ItemId",
                principalTable: "ItemStock",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMovement_Order_OrderId",
                table: "InventoryMovement",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMovement_ProductLocation_FromProductLocationId",
                table: "InventoryMovement",
                column: "FromProductLocationId",
                principalTable: "ProductLocation",
                principalColumn: "ItemLocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMovement_ProductLocation_ToProductLocationId",
                table: "InventoryMovement",
                column: "ToProductLocationId",
                principalTable: "ProductLocation",
                principalColumn: "ItemLocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Customer_CustomerId",
                table: "Invoice",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Supplier_SupplierId",
                table: "Invoice",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Island_WarehouseSection_WarehouseSectionsId",
                table: "Island",
                column: "WarehouseSectionsId",
                principalTable: "WarehouseSection",
                principalColumn: "WarehouseSectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IslandPosition_Island_IslandId",
                table: "IslandPosition",
                column: "IslandId",
                principalTable: "Island",
                principalColumn: "IslandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemStock_Order_OrderId",
                table: "ItemStock",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemStock_ProductLocation_ItemLocationId",
                table: "ItemStock",
                column: "ItemLocationId",
                principalTable: "ProductLocation",
                principalColumn: "ItemLocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemStock_Product_ProductId",
                table: "ItemStock",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Employee_EmployeeId",
                table: "Order",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Invoice_InvoiceId",
                table: "Order",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Order_OrderId",
                table: "OrderProduct",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Product_ProductId",
                table: "OrderProduct",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategorie_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "ProductCategorie",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLocation_AisleSectionPosition_PositionId",
                table: "ProductLocation",
                column: "PositionId",
                principalTable: "AisleSectionPosition",
                principalColumn: "AisleSectionPositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLocation_Bin_BinId",
                table: "ProductLocation",
                column: "BinId",
                principalTable: "Bin",
                principalColumn: "BinId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLocation_IslandPosition_IslandPositionId",
                table: "ProductLocation",
                column: "IslandPositionId",
                principalTable: "IslandPosition",
                principalColumn: "IslandPositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_StraightLine_WarehouseSection_WarehouseSectionId",
                table: "StraightLine",
                column: "WarehouseSectionId",
                principalTable: "WarehouseSection",
                principalColumn: "WarehouseSectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseSection_Warehouse_WarehouseId",
                table: "WarehouseSection",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aisle_StraightLine_StraightLineId",
                table: "Aisle");

            migrationBuilder.DropForeignKey(
                name: "FK_AisleSection_Aisle_AisleId",
                table: "AisleSection");

            migrationBuilder.DropForeignKey(
                name: "FK_AisleSectionPosition_AisleSection_AisleSectionId",
                table: "AisleSectionPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_Bin_BinStorage_BinStorageId",
                table: "Bin");

            migrationBuilder.DropForeignKey(
                name: "FK_BinStorage_WarehouseSection_WarehouseSectionsId",
                table: "BinStorage");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Role_RoleId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMovement_Employee_MovementByEmployeeId",
                table: "InventoryMovement");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMovement_ItemStock_ItemId",
                table: "InventoryMovement");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMovement_Order_OrderId",
                table: "InventoryMovement");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMovement_ProductLocation_FromProductLocationId",
                table: "InventoryMovement");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMovement_ProductLocation_ToProductLocationId",
                table: "InventoryMovement");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Customer_CustomerId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Supplier_SupplierId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Island_WarehouseSection_WarehouseSectionsId",
                table: "Island");

            migrationBuilder.DropForeignKey(
                name: "FK_IslandPosition_Island_IslandId",
                table: "IslandPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemStock_Order_OrderId",
                table: "ItemStock");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemStock_ProductLocation_ItemLocationId",
                table: "ItemStock");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemStock_Product_ProductId",
                table: "ItemStock");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Employee_EmployeeId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Invoice_InvoiceId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Order_OrderId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Product_ProductId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCategorie_CategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLocation_AisleSectionPosition_PositionId",
                table: "ProductLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLocation_Bin_BinId",
                table: "ProductLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLocation_IslandPosition_IslandPositionId",
                table: "ProductLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_StraightLine_WarehouseSection_WarehouseSectionId",
                table: "StraightLine");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseSection_Warehouse_WarehouseId",
                table: "WarehouseSection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WarehouseSection",
                table: "WarehouseSection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StraightLine",
                table: "StraightLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductLocation",
                table: "ProductLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategorie",
                table: "ProductCategorie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProduct",
                table: "OrderProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemStock",
                table: "ItemStock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IslandPosition",
                table: "IslandPosition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Island",
                table: "Island");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryMovement",
                table: "InventoryMovement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BinStorage",
                table: "BinStorage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bin",
                table: "Bin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AisleSectionPosition",
                table: "AisleSectionPosition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AisleSection",
                table: "AisleSection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aisle",
                table: "Aisle");

            migrationBuilder.RenameTable(
                name: "WarehouseSection",
                newName: "WarehouseSections");

            migrationBuilder.RenameTable(
                name: "Warehouse",
                newName: "Warehouses");

            migrationBuilder.RenameTable(
                name: "Supplier",
                newName: "Suppliers");

            migrationBuilder.RenameTable(
                name: "StraightLine",
                newName: "StraightLines");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "ProductLocation",
                newName: "ProductLocations");

            migrationBuilder.RenameTable(
                name: "ProductCategorie",
                newName: "ProductCategories");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "OrderProduct",
                newName: "OrderProducts");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "ItemStock",
                newName: "ItemStocks");

            migrationBuilder.RenameTable(
                name: "IslandPosition",
                newName: "IslandPositions");

            migrationBuilder.RenameTable(
                name: "Island",
                newName: "Islands");

            migrationBuilder.RenameTable(
                name: "Invoice",
                newName: "Invoices");

            migrationBuilder.RenameTable(
                name: "InventoryMovement",
                newName: "InventoryMovements");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "BinStorage",
                newName: "BinStorages");

            migrationBuilder.RenameTable(
                name: "Bin",
                newName: "Bins");

            migrationBuilder.RenameTable(
                name: "AisleSectionPosition",
                newName: "AisleSectionPositions");

            migrationBuilder.RenameTable(
                name: "AisleSection",
                newName: "AisleSections");

            migrationBuilder.RenameTable(
                name: "Aisle",
                newName: "Aisles");

            migrationBuilder.RenameIndex(
                name: "IX_WarehouseSection_WarehouseId",
                table: "WarehouseSections",
                newName: "IX_WarehouseSections_WarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_StraightLine_WarehouseSectionId",
                table: "StraightLines",
                newName: "IX_StraightLines_WarehouseSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductLocation_PositionId",
                table: "ProductLocations",
                newName: "IX_ProductLocations_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductLocation_IslandPositionId",
                table: "ProductLocations",
                newName: "IX_ProductLocations_IslandPositionId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductLocation_BinId",
                table: "ProductLocations",
                newName: "IX_ProductLocations_BinId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProduct_ProductId",
                table: "OrderProducts",
                newName: "IX_OrderProducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_InvoiceId",
                table: "Orders",
                newName: "IX_Orders_InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_EmployeeId",
                table: "Orders",
                newName: "IX_Orders_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemStock_ProductId",
                table: "ItemStocks",
                newName: "IX_ItemStocks_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemStock_OrderId",
                table: "ItemStocks",
                newName: "IX_ItemStocks_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemStock_ItemLocationId",
                table: "ItemStocks",
                newName: "IX_ItemStocks_ItemLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_IslandPosition_IslandId",
                table: "IslandPositions",
                newName: "IX_IslandPositions_IslandId");

            migrationBuilder.RenameIndex(
                name: "IX_Island_WarehouseSectionsId",
                table: "Islands",
                newName: "IX_Islands_WarehouseSectionsId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_SupplierId",
                table: "Invoices",
                newName: "IX_Invoices_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_CustomerId",
                table: "Invoices",
                newName: "IX_Invoices_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryMovement_ToProductLocationId",
                table: "InventoryMovements",
                newName: "IX_InventoryMovements_ToProductLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryMovement_OrderId",
                table: "InventoryMovements",
                newName: "IX_InventoryMovements_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryMovement_MovementByEmployeeId",
                table: "InventoryMovements",
                newName: "IX_InventoryMovements_MovementByEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryMovement_ItemId",
                table: "InventoryMovements",
                newName: "IX_InventoryMovements_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryMovement_FromProductLocationId",
                table: "InventoryMovements",
                newName: "IX_InventoryMovements_FromProductLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_RoleId",
                table: "Employees",
                newName: "IX_Employees_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_BinStorage_WarehouseSectionsId",
                table: "BinStorages",
                newName: "IX_BinStorages_WarehouseSectionsId");

            migrationBuilder.RenameIndex(
                name: "IX_Bin_BinStorageId",
                table: "Bins",
                newName: "IX_Bins_BinStorageId");

            migrationBuilder.RenameIndex(
                name: "IX_AisleSectionPosition_AisleSectionId",
                table: "AisleSectionPositions",
                newName: "IX_AisleSectionPositions_AisleSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_AisleSection_AisleId",
                table: "AisleSections",
                newName: "IX_AisleSections_AisleId");

            migrationBuilder.RenameIndex(
                name: "IX_Aisle_StraightLineId",
                table: "Aisles",
                newName: "IX_Aisles_StraightLineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WarehouseSections",
                table: "WarehouseSections",
                column: "WarehouseSectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouses",
                table: "Warehouses",
                column: "WarehouseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "SupplierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StraightLines",
                table: "StraightLines",
                column: "StraightLineID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductLocations",
                table: "ProductLocations",
                column: "ItemLocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemStocks",
                table: "ItemStocks",
                column: "ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IslandPositions",
                table: "IslandPositions",
                column: "IslandPositionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Islands",
                table: "Islands",
                column: "IslandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryMovements",
                table: "InventoryMovements",
                column: "InventoryMovementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BinStorages",
                table: "BinStorages",
                column: "BinStorageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bins",
                table: "Bins",
                column: "BinId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AisleSectionPositions",
                table: "AisleSectionPositions",
                column: "AisleSectionPositionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AisleSections",
                table: "AisleSections",
                column: "AisleSectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aisles",
                table: "Aisles",
                column: "AisleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aisles_StraightLines_StraightLineId",
                table: "Aisles",
                column: "StraightLineId",
                principalTable: "StraightLines",
                principalColumn: "StraightLineID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AisleSectionPositions_AisleSections_AisleSectionId",
                table: "AisleSectionPositions",
                column: "AisleSectionId",
                principalTable: "AisleSections",
                principalColumn: "AisleSectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AisleSections_Aisles_AisleId",
                table: "AisleSections",
                column: "AisleId",
                principalTable: "Aisles",
                principalColumn: "AisleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bins_BinStorages_BinStorageId",
                table: "Bins",
                column: "BinStorageId",
                principalTable: "BinStorages",
                principalColumn: "BinStorageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BinStorages_WarehouseSections_WarehouseSectionsId",
                table: "BinStorages",
                column: "WarehouseSectionsId",
                principalTable: "WarehouseSections",
                principalColumn: "WarehouseSectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Roles_RoleId",
                table: "Employees",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMovements_Employees_MovementByEmployeeId",
                table: "InventoryMovements",
                column: "MovementByEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMovements_ItemStocks_ItemId",
                table: "InventoryMovements",
                column: "ItemId",
                principalTable: "ItemStocks",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMovements_Orders_OrderId",
                table: "InventoryMovements",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMovements_ProductLocations_FromProductLocationId",
                table: "InventoryMovements",
                column: "FromProductLocationId",
                principalTable: "ProductLocations",
                principalColumn: "ItemLocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMovements_ProductLocations_ToProductLocationId",
                table: "InventoryMovements",
                column: "ToProductLocationId",
                principalTable: "ProductLocations",
                principalColumn: "ItemLocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Customers_CustomerId",
                table: "Invoices",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Suppliers_SupplierId",
                table: "Invoices",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_IslandPositions_Islands_IslandId",
                table: "IslandPositions",
                column: "IslandId",
                principalTable: "Islands",
                principalColumn: "IslandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Islands_WarehouseSections_WarehouseSectionsId",
                table: "Islands",
                column: "WarehouseSectionsId",
                principalTable: "WarehouseSections",
                principalColumn: "WarehouseSectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemStocks_Orders_OrderId",
                table: "ItemStocks",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemStocks_ProductLocations_ItemLocationId",
                table: "ItemStocks",
                column: "ItemLocationId",
                principalTable: "ProductLocations",
                principalColumn: "ItemLocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemStocks_Products_ProductId",
                table: "ItemStocks",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Products_ProductId",
                table: "OrderProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Employees_EmployeeId",
                table: "Orders",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Invoices_InvoiceId",
                table: "Orders",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLocations_AisleSectionPositions_PositionId",
                table: "ProductLocations",
                column: "PositionId",
                principalTable: "AisleSectionPositions",
                principalColumn: "AisleSectionPositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLocations_Bins_BinId",
                table: "ProductLocations",
                column: "BinId",
                principalTable: "Bins",
                principalColumn: "BinId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLocations_IslandPositions_IslandPositionId",
                table: "ProductLocations",
                column: "IslandPositionId",
                principalTable: "IslandPositions",
                principalColumn: "IslandPositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "ProductCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StraightLines_WarehouseSections_WarehouseSectionId",
                table: "StraightLines",
                column: "WarehouseSectionId",
                principalTable: "WarehouseSections",
                principalColumn: "WarehouseSectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseSections_Warehouses_WarehouseId",
                table: "WarehouseSections",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
