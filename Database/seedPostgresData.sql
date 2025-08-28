INSERT INTO "Warehouses" (
    "WarehouseName", "Address", "State", "Country", "ZipCode",
    "OwnerName", "Phone", "Email",
    "CreatedBy", "CreatedDate", "UpdatedBy", "UpdateDate"
) VALUES
      ('North Hub', '123 Maple Ave', 'Illinois', 'USA', '60601', 'Fisher', '312-555-0101', 'john.smith@example.com', 'system', NOW() AT TIME ZONE 'US/Central', 'system', NOW() AT TIME ZONE 'US/Central'),
      ('East Distribution', '456 Oak Street', 'New York', 'USA', '10001', 'Fisher', '212-555-0123', 'sarah.johnson@example.com', 'system', NOW() AT TIME ZONE 'US/Central', 'system', NOW() AT TIME ZONE 'US/Central'),
      ('West Storage', '789 Pine Blvd', 'California', 'USA', '90001', 'Bob Co.', '310-555-0145', 'michael.brown@example.com', 'system', NOW() AT TIME ZONE 'US/Central', 'system', NOW() AT TIME ZONE 'US/Central'),
      ('South Logistics', '101 Elm Dr', 'Texas', 'USA', '73301', 'Davis Inc.', '512-555-0167', 'emily.davis@example.com', 'system', NOW() AT TIME ZONE 'US/Central', 'system', NOW() AT TIME ZONE 'US/Central'),
      ('Central Depot', '202 Cedar Rd', 'Ohio', 'USA', '44101', 'Kermit', '216-555-0189', 'daniel.wilson@example.com', 'system', NOW() AT TIME ZONE 'US/Central', 'system', NOW() AT TIME ZONE 'US/Central');


