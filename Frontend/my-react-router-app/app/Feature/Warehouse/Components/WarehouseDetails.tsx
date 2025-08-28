import { useEffect, useState } from "react";
import { useParams, Link } from "react-router-dom";
import type { Warehouse } from "../Types/warehouse";

export default function WarehouseDetails() {
    const { id } = useParams<{ id: string }>();
    const [warehouse, setWarehouse] = useState<Warehouse | null>(null);
    const [loading, setLoading] = useState(true);


    useEffect(() => {
        const fetchWarehouse = async () => {
            const res = await fetch(`/api/warehouse/${id}`); // backend API
            const data: Warehouse = await res.json();
            setWarehouse(data);
        };
        fetchWarehouse();
    }, [id]);

    if (loading) return <p className="text-gray-500">Loading...</p>;
    if (!warehouse) return <p className="text-red-500">Warehouse not found.</p>;

    return (
        <div className="max-w-3xl mx-auto p-6 bg-white rounded-2xl shadow-md">
            <h2 className="text-2xl font-bold mb-4">Warehouse Details</h2>
            <div className="grid grid-cols-2 gap-4">
                <DetailItem label="Name" value={warehouse.warehouseName} />
                <DetailItem label="Address" value={warehouse.address} />
                <DetailItem label="State" value={warehouse.state} />
                <DetailItem label="Country" value={warehouse.country} />
                <DetailItem label="Zip Code" value={warehouse.zipCode.toString()} />
                <DetailItem label="Owner" value={warehouse.ownerName} />
                <DetailItem label="Phone" value={warehouse.phone.toString()} />
                <DetailItem label="Email" value={warehouse.email} />
                <DetailItem label="Created By" value={warehouse.createdBy.toString()} />
                <DetailItem label="Created Date" value={new Date(warehouse.createdDate).toLocaleString()} />
                <DetailItem label="Updated By" value={warehouse.updatedBy.toString()} />
                <DetailItem label="Update Date" value={new Date(warehouse.updateDate).toLocaleString()} />
            </div>

            {warehouse.warehouseSections && warehouse.warehouseSections.length > 0 && (
                <div className="mt-6">
                    <h3 className="text-lg font-semibold mb-2">Sections</h3>
                    <ul className="list-disc list-inside text-gray-700">
                        {warehouse.warehouseSections.map(warehouseSection  =>
                            (
                                <li key={warehouseSection.id}>{warehouseSection.name}</li>
                            ))}
                    </ul>
                </div>
            )}

            <div className="mt-6 flex gap-3">
                <Link to="/warehouses" className="px-4 py-2 bg-gray-200 rounded-lg hover:bg-gray-300">
                    Back to List
                </Link>
                <Link
                    to={`/warehouses/edit/${warehouse.warehouseId}`}
                    className="px-4 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700"
                >
                    Edit
                </Link>
            </div>
        </div>
    );
}

function DetailItem({ label, value }: { label: string; value: string }) {
    return (
        <div>
            <p className="text-sm text-gray-500">{label}</p>
            <p className="font-medium">{value}</p>
        </div>
    );
}
