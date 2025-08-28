export interface Warehouse {
    warehouseId: number;
    warehouseName: string;
    address: string;
    state: string;
    country: string;
    zipCode: number;
    ownerName: string;
    phone: string;
    email: string;
    createdBy: number;
    createdDate: string;
    updatedBy: number;
    updateDate: string;
    warehouseSections?: WarehouseSection[];
}

export interface WarehouseSection {
    id: number;
    name: string;
    capacity?: number;
    currentStock?: number;
}