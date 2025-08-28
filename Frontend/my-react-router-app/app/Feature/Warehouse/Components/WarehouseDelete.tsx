import React, { useEffect, useState } from "react";

type Warehouse = {
    warehouseId: number;
    warehouseName: string;
    address: string;
    state: string;
    country: string;
    ownerName: string;
    email: string;
};

const WarehouseTable: React.FC = () => {
    const [warehouses, setWarehouses] = useState<Warehouse[]>([]);
    const [selectedId, setSelectedId] = useState<number | null>(null);

    // Fetch warehouses on load
    useEffect(() => {
        const fetchWarehouses = async () => {
            try {
                const response = await fetch("/api/warehouse");
                if (response.ok) {
                    const data = await response.json();
                    setWarehouses(data);
                } else {
                    console.error("Failed to fetch warehouses");
                }
            } catch (error) {
                console.error("Error fetching warehouses:", error);
            }
        };

        fetchWarehouses();
    }, []);

    const handleDelete = async () => {
        if (selectedId === null) return;

        try {
            const response = await fetch(`/api/warehouse/${selectedId}`, {
                method: "DELETE",
            });

            if (response.ok) {
                setWarehouses((prev) =>
                    prev.filter((w) => w.warehouseId !== selectedId)
                );
                setSelectedId(null);
            } else {
                console.error("Failed to delete warehouse");
            }
        } catch (error) {
            console.error("Error deleting warehouse:", error);
        }
    };

    return (
        <div className="p-6">
            <h2 className="text-xl font-bold mb-4">Warehouse List</h2>
            <table className="table-auto border-collapse border border-gray-300 w-full">
                <thead className="bg-gray-100">
                <tr>
                    <th className="border p-2">Warehouse Name</th>
                    <th className="border p-2">Address</th>
                    <th className="border p-2">State</th>
                    <th className="border p-2">Country</th>
                    <th className="border p-2">Owner Name</th>
                    <th className="border p-2">Email</th>
                </tr>
                </thead>
                <tbody>
                {warehouses.map((w) => (
                    <tr
                        key={w.warehouseId}
                        onClick={() => setSelectedId(w.warehouseId)}
                        className={`cursor-pointer ${
                            selectedId === w.warehouseId ? "bg-blue-100" : ""
                        }`}
                    >
                        <td className="border p-2">{w.warehouseName}</td>
                        <td className="border p-2">{w.address}</td>
                        <td className="border p-2">{w.state}</td>
                        <td className="border p-2">{w.country}</td>
                        <td className="border p-2">{w.ownerName}</td>
                        <td className="border p-2">{w.email}</td>
                    </tr>
                ))}
                </tbody>
            </table>

            <div className="mt-4">
                <button
                    onClick={handleDelete}
                    disabled={selectedId === null}
                    className={`px-4 py-2 rounded ${
                        selectedId === null
                            ? "bg-gray-400 text-gray-200 cursor-not-allowed"
                            : "bg-red-500 text-white hover:bg-red-600"
                    }`}
                >
                    Delete Selected
                </button>
            </div>
        </div>
    );
};

export default WarehouseTable;
