import { useState, useEffect } from 'react';
import { Building, MapPin, User, Phone, Mail, RefreshCw, Eye } from 'lucide-react';

const WarehouseListTable = () => {
    const [warehouses, setWarehouses] = useState([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);
    const [selectedWarehouse, setSelectedWarehouse] = useState(null);

    const fetchWarehouses = async () => {
        setLoading(true);
        setError(null);

        try {
            // Replace with your actual API base URL
            const response = await fetch('/api/warehouse');

            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }

            const data = await response.json();
            setWarehouses(data);
        } catch (err) {
            setError(err.message || 'Failed to fetch warehouses');
            setWarehouses([]);
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        fetchWarehouses();
    }, []);

    const formatDate = (dateString) => {
        if (!dateString) return 'N/A';
        return new Date(dateString).toLocaleDateString('en-US', {
            year: 'numeric',
            month: 'short',
            day: 'numeric'
        });
    };

    const formatAddress = (warehouse) => {
        return `${warehouse.address}, ${warehouse.state}, ${warehouse.country} ${warehouse.zipCode}`;
    };

    const handleViewDetails = (warehouse) => {
        setSelectedWarehouse(warehouse);
    };

    const closeModal = () => {
        setSelectedWarehouse(null);
    };

    return (
        <div className="min-h-screen bg-gray-50 py-8">
            <div className="max-w-7xl mx-auto px-4">
                {/* Header */}
                <div className="bg-white rounded-lg shadow-md p-6 mb-6">
                    <div className="flex justify-between items-center">
                        <h1 className="text-3xl font-bold text-gray-800 flex items-center">
                            <Building className="mr-3 text-blue-600" />
                            Warehouse Directory
                        </h1>
                        <button
                            onClick={fetchWarehouses}
                            disabled={loading}
                            className="px-4 py-2 bg-blue-600 text-white rounded-md hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-offset-2 disabled:opacity-50 disabled:cursor-not-allowed flex items-center"
                        >
                            <RefreshCw className={`w-4 h-4 mr-2 ${loading ? 'animate-spin' : ''}`} />
                            {loading ? 'Refreshing...' : 'Refresh'}
                        </button>
                    </div>
                </div>

                {/* Error Message */}
                {error && (
                    <div className="bg-red-50 border border-red-200 rounded-md p-4 mb-6">
                        <p className="text-red-800">{error}</p>
                    </div>
                )}

                {/* Loading State */}
                {loading && warehouses.length === 0 && (
                    <div className="bg-white rounded-lg shadow-md p-8">
                        <div className="flex items-center justify-center">
                            <div className="animate-spin rounded-full h-12 w-12 border-b-2 border-blue-600"></div>
                        </div>
                    </div>
                )}

                {/* Warehouse Table */}
                {!loading && warehouses.length > 0 && (
                    <div className="bg-white rounded-lg shadow-md overflow-hidden">
                        <div className="overflow-x-auto">
                            <table className="w-full divide-y divide-gray-200">
                                <thead className="bg-gray-50">
                                <tr>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                                        Warehouse
                                    </th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                                        Location
                                    </th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                                        Owner
                                    </th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                                        Contact
                                    </th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                                        Created
                                    </th>
                                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                                        Actions
                                    </th>
                                </tr>
                                </thead>
                                <tbody className="bg-white divide-y divide-gray-200">
                                {warehouses.map((warehouse) => (
                                    <tr key={warehouse.warehouseId} className="hover:bg-gray-50">
                                        <td className="px-6 py-4 whitespace-nowrap">
                                            <div className="flex items-center">
                                                <Building className="w-5 h-5 text-gray-400 mr-3" />
                                                <div>
                                                    <div className="text-sm font-medium text-gray-900">
                                                        {warehouse.warehouseName}
                                                    </div>
                                                    <div className="text-sm text-gray-500">
                                                        ID: {warehouse.warehouseId}
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                        <td className="px-6 py-4">
                                            <div className="flex items-start">
                                                <MapPin className="w-4 h-4 text-gray-400 mr-2 mt-0.5 flex-shrink-0" />
                                                <div className="text-sm text-gray-900">
                                                    <div>{warehouse.address}</div>
                                                    <div className="text-gray-500">
                                                        {warehouse.state}, {warehouse.country} {warehouse.zipCode}
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                        <td className="px-6 py-4 whitespace-nowrap">
                                            <div className="flex items-center">
                                                <User className="w-4 h-4 text-gray-400 mr-2" />
                                                <div className="text-sm text-gray-900">
                                                    {warehouse.ownerName}
                                                </div>
                                            </div>
                                        </td>
                                        <td className="px-6 py-4">
                                            <div className="space-y-1">
                                                <div className="flex items-center text-sm text-gray-900">
                                                    <Phone className="w-3 h-3 text-gray-400 mr-2" />
                                                    {warehouse.phone}
                                                </div>
                                                <div className="flex items-center text-sm text-gray-900">
                                                    <Mail className="w-3 h-3 text-gray-400 mr-2" />
                                                    {warehouse.email}
                                                </div>
                                            </div>
                                        </td>
                                        <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-900">
                                            {formatDate(warehouse.createdDate)}
                                        </td>
                                        <td className="px-6 py-4 whitespace-nowrap text-sm font-medium">
                                            <button
                                                onClick={() => handleViewDetails(warehouse)}
                                                className="text-blue-600 hover:text-blue-900 flex items-center"
                                            >
                                                <Eye className="w-4 h-4 mr-1" />
                                                View Details
                                            </button>
                                        </td>
                                    </tr>
                                ))}
                                </tbody>
                            </table>
                        </div>
                    </div>
                )}

                {/* No Results */}
                {!loading && warehouses.length === 0 && !error && (
                    <div className="bg-white rounded-lg shadow-md p-8 text-center">
                        <Building className="w-12 h-12 text-gray-400 mx-auto mb-4" />
                        <h3 className="text-lg font-medium text-gray-900 mb-2">No warehouses found</h3>
                        <p className="text-gray-500">There are no warehouses to display at the moment.</p>
                    </div>
                )}

                {/* Summary */}
                {warehouses.length > 0 && (
                    <div className="mt-4 text-center text-sm text-gray-600">
                        Showing {warehouses.length} warehouse{warehouses.length !== 1 ? 's' : ''}
                    </div>
                )}
            </div>

            {/* Detail Modal */}
            {selectedWarehouse && (
                <div className="fixed inset-0 bg-gray-600 bg-opacity-50 overflow-y-auto h-full w-full z-50" onClick={closeModal}>
                    <div className="relative top-20 mx-auto p-5 border w-11/12 md:w-2/3 lg:w-1/2 shadow-lg rounded-md bg-white" onClick={(e) => e.stopPropagation()}>
                        <div className="mt-3">
                            <div className="flex justify-between items-center mb-4">
                                <h3 className="text-2xl font-bold text-gray-800 flex items-center">
                                    <Building className="mr-2 text-blue-600" />
                                    {selectedWarehouse.warehouseName}
                                </h3>
                                <button
                                    onClick={closeModal}
                                    className="text-gray-400 hover:text-gray-600 text-2xl font-bold"
                                >
                                    ×
                                </button>
                            </div>

                            <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
                                <div className="space-y-4">
                                    <h4 className="font-semibold text-gray-800 border-b border-gray-200 pb-2">
                                        Basic Information
                                    </h4>

                                    <div className="space-y-3">
                                        <div>
                                            <p className="font-medium text-gray-800">Warehouse ID</p>
                                            <p className="text-gray-600">{selectedWarehouse.warehouseId}</p>
                                        </div>

                                        <div>
                                            <p className="font-medium text-gray-800">Full Address</p>
                                            <p className="text-gray-600">{formatAddress(selectedWarehouse)}</p>
                                        </div>
                                    </div>
                                </div>

                                <div className="space-y-4">
                                    <h4 className="font-semibold text-gray-800 border-b border-gray-200 pb-2">
                                        Contact & Management
                                    </h4>

                                    <div className="space-y-3">
                                        <div>
                                            <p className="font-medium text-gray-800">Owner</p>
                                            <p className="text-gray-600">{selectedWarehouse.ownerName}</p>
                                        </div>

                                        <div>
                                            <p className="font-medium text-gray-800">Phone</p>
                                            <p className="text-gray-600">{selectedWarehouse.phone}</p>
                                        </div>

                                        <div>
                                            <p className="font-medium text-gray-800">Email</p>
                                            <p className="text-gray-600">{selectedWarehouse.email}</p>
                                        </div>
                                    </div>
                                </div>

                                <div className="md:col-span-2 pt-4 border-t border-gray-200">
                                    <h4 className="font-semibold text-gray-800 mb-4">Record Information</h4>

                                    <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                                        <div>
                                            <p className="font-medium text-gray-800">Created</p>
                                            <p className="text-sm text-gray-600">
                                                {formatDate(selectedWarehouse.createdDate)} by User {selectedWarehouse.createdBy}
                                            </p>
                                        </div>

                                        <div>
                                            <p className="font-medium text-gray-800">Last Updated</p>
                                            <p className="text-sm text-gray-600">
                                                {formatDate(selectedWarehouse.updateDate)} by User {selectedWarehouse.updatedBy}
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div className="mt-6 flex justify-end">
                                <button
                                    onClick={closeModal}
                                    className="px-4 py-2 bg-gray-600 text-white rounded-md hover:bg-gray-700 focus:outline-none focus:ring-2 focus:ring-gray-500 focus:ring-offset-2"
                                >
                                    Close
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            )}
        </div>
    );
};

export default WarehouseListTable;