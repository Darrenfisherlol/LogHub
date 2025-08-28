import React, { useState } from 'react';

interface FormData {
    warehouseName: string;
    address: string;
    state: string;
    country: string;
    zipCode: string;
    ownerName: string;
    phone: string;
    email: string;
}

interface FormErrors {
    [key: string]: string;
}

interface WarehouseResponseDto {
    warehouseId: number;
    warehouseName: string;
    address: string;
    state: string;
    country: string;
    zipCode: string;
    ownerName: string;
    phone: string;
    email: string;
    createdDate: string;
    updateDate: string;
    isActive: boolean;
}

const CreateWarehousePage: React.FC = () => {
    const [formData, setFormData] = useState<FormData>({
        warehouseName: '',
        address: '',
        state: '',
        country: '',
        zipCode: '',
        ownerName: '',
        phone: '',
        email: ''
    });

    const [errors, setErrors] = useState<FormErrors>({});
    const [loading, setLoading] = useState<boolean>(false);
    const [success, setSuccess] = useState<boolean>(false);

    const validateForm = (): boolean => {
        const newErrors: FormErrors = {};

        if (!formData.warehouseName.trim()) {
            newErrors.warehouseName = 'Warehouse name is required';
        }

        if (!formData.address.trim()) {
            newErrors.address = 'Address is required';
        }

        if (formData.email && !/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(formData.email)) {
            newErrors.email = 'Please enter a valid email address';
        }

        if (formData.phone && !/^[\d\s\-\+\(\)]+$/.test(formData.phone)) {
            newErrors.phone = 'Please enter a valid phone number';
        }

        if (formData.zipCode && !/^\d{5}(-\d{4})?$/.test(formData.zipCode)) {
            newErrors.zipCode = 'Please enter a valid ZIP code (12345 or 12345-6789)';
        }

        setErrors(newErrors);
        return Object.keys(newErrors).length === 0;
    };

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>): void => {
        const { name, value } = e.target;
        setFormData(prev => ({
            ...prev,
            [name]: value
        }));

        // Clear error when user starts typing
        if (errors[name]) {
            setErrors(prev => ({
                ...prev,
                [name]: ''
            }));
        }
    };

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>): Promise<void> => {
        e.preventDefault();

        if (!validateForm()) return;

        setLoading(true);
        setSuccess(false);

        try {
            const response = await fetch('/api/warehouse', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    // Add authorization header if needed
                    // 'Authorization': `Bearer ${token}`
                },
                body: JSON.stringify(formData)
            });

            if (!response.ok) {
                const errorData = await response.json();

                // Handle validation errors from server
                if (response.status === 400 && errorData.errors) {
                    const serverErrors: FormErrors = {};
                    Object.keys(errorData.errors).forEach((key: string) => {
                        const fieldName = key.charAt(0).toLowerCase() + key.slice(1);
                        serverErrors[fieldName] = errorData.errors[key][0];
                    });
                    setErrors(serverErrors);
                    return;
                }

                throw new Error(errorData.message || 'Failed to create warehouse');
            }

            const createdWarehouse: WarehouseResponseDto = await response.json();
            console.log('Warehouse created:', createdWarehouse);

            setSuccess(true);
            // Reset form
            setFormData({
                warehouseName: '',
                address: '',
                state: '',
                country: '',
                zipCode: '',
                ownerName: '',
                phone: '',
                email: ''
            });

        } catch (error) {
            console.error('Error creating warehouse:', error);
            setErrors({ general: (error as Error).message });
        } finally {
            setLoading(false);
        }
    };

    const handleReset = (): void => {
        setFormData({
            warehouseName: '',
            address: '',
            state: '',
            country: '',
            zipCode: '',
            ownerName: '',
            phone: '',
            email: ''
        });
        setErrors({});
        setSuccess(false);
    };

    return (
        <div className="max-w-2xl mx-auto p-6 bg-white rounded-lg shadow-md">
            <h1 className="text-2xl font-bold text-gray-800 mb-6">Create New Warehouse</h1>

            {success && (
                <div className="mb-4 p-4 bg-green-100 border border-green-400 text-green-700 rounded">
                    <div className="flex items-center">
                        <svg className="w-5 h-5 mr-2" fill="currentColor" viewBox="0 0 20 20">
                            <path fillRule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.707-9.293a1 1 0 00-1.414-1.414L9 10.586 7.707 9.293a1 1 0 00-1.414 1.414l2 2a1 1 0 001.414 0l4-4z" clipRule="evenodd" />
                        </svg>
                        Warehouse created successfully!
                    </div>
                </div>
            )}

            {errors.general && (
                <div className="mb-4 p-4 bg-red-100 border border-red-400 text-red-700 rounded">
                    <div className="flex items-center">
                        <svg className="w-5 h-5 mr-2" fill="currentColor" viewBox="0 0 20 20">
                            <path fillRule="evenodd" d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-7 4a1 1 0 11-2 0 1 1 0 012 0zm-1-9a1 1 0 00-1 1v4a1 1 0 102 0V6a1 1 0 00-1-1z" clipRule="evenodd" />
                        </svg>
                        {errors.general}
                    </div>
                </div>
            )}

            <form onSubmit={handleSubmit} className="space-y-4">
                <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                    {/* Warehouse Name */}
                    <div className="md:col-span-2">
                        <label htmlFor="warehouseName" className="block text-sm font-medium text-gray-700 mb-1">
                            Warehouse Name *
                        </label>
                        <input
                            type="text"
                            id="warehouseName"
                            name="warehouseName"
                            value={formData.warehouseName}
                            onChange={handleInputChange}
                            className={`w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 ${
                                errors.warehouseName ? 'border-red-500' : 'border-gray-300'
                            }`}
                            placeholder="Enter warehouse name"
                        />
                        {errors.warehouseName && (
                            <p className="mt-1 text-sm text-red-600">{errors.warehouseName}</p>
                        )}
                    </div>

                    {/* Address */}
                    <div className="md:col-span-2">
                        <label htmlFor="address" className="block text-sm font-medium text-gray-700 mb-1">
                            Address *
                        </label>
                        <textarea
                            id="address"
                            name="address"
                            value={formData.address}
                            onChange={handleInputChange}
                            rows={3}
                            className={`w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 ${
                                errors.address ? 'border-red-500' : 'border-gray-300'
                            }`}
                            placeholder="Enter complete address"
                        />
                        {errors.address && (
                            <p className="mt-1 text-sm text-red-600">{errors.address}</p>
                        )}
                    </div>

                    {/* State */}
                    <div>
                        <label htmlFor="state" className="block text-sm font-medium text-gray-700 mb-1">
                            State
                        </label>
                        <input
                            type="text"
                            id="state"
                            name="state"
                            value={formData.state}
                            onChange={handleInputChange}
                            className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                            placeholder="Enter state"
                        />
                    </div>

                    {/* Country */}
                    <div>
                        <label htmlFor="country" className="block text-sm font-medium text-gray-700 mb-1">
                            Country
                        </label>
                        <input
                            type="text"
                            id="country"
                            name="country"
                            value={formData.country}
                            onChange={handleInputChange}
                            className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                            placeholder="Enter country"
                        />
                    </div>

                    {/* ZIP Code */}
                    <div>
                        <label htmlFor="zipCode" className="block text-sm font-medium text-gray-700 mb-1">
                            ZIP Code
                        </label>
                        <input
                            type="text"
                            id="zipCode"
                            name="zipCode"
                            value={formData.zipCode}
                            onChange={handleInputChange}
                            className={`w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 ${
                                errors.zipCode ? 'border-red-500' : 'border-gray-300'
                            }`}
                            placeholder="12345 or 12345-6789"
                        />
                        {errors.zipCode && (
                            <p className="mt-1 text-sm text-red-600">{errors.zipCode}</p>
                        )}
                    </div>

                    {/* Owner Name */}
                    <div>
                        <label htmlFor="ownerName" className="block text-sm font-medium text-gray-700 mb-1">
                            Owner Name
                        </label>
                        <input
                            type="text"
                            id="ownerName"
                            name="ownerName"
                            value={formData.ownerName}
                            onChange={handleInputChange}
                            className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                            placeholder="Enter owner name"
                        />
                    </div>

                    {/* Phone */}
                    <div>
                        <label htmlFor="phone" className="block text-sm font-medium text-gray-700 mb-1">
                            Phone
                        </label>
                        <input
                            type="tel"
                            id="phone"
                            name="phone"
                            value={formData.phone}
                            onChange={handleInputChange}
                            className={`w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 ${
                                errors.phone ? 'border-red-500' : 'border-gray-300'
                            }`}
                            placeholder="(555) 123-4567"
                        />
                        {errors.phone && (
                            <p className="mt-1 text-sm text-red-600">{errors.phone}</p>
                        )}
                    </div>

                    {/* Email */}
                    <div>
                        <label htmlFor="email" className="block text-sm font-medium text-gray-700 mb-1">
                            Email
                        </label>
                        <input
                            type="email"
                            id="email"
                            name="email"
                            value={formData.email}
                            onChange={handleInputChange}
                            className={`w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 ${
                                errors.email ? 'border-red-500' : 'border-gray-300'
                            }`}
                            placeholder="owner@example.com"
                        />
                        {errors.email && (
                            <p className="mt-1 text-sm text-red-600">{errors.email}</p>
                        )}
                    </div>
                </div>

                {/* Form Actions */}
                <div className="flex justify-end space-x-4 pt-4">
                    <button
                        type="button"
                        onClick={handleReset}
                        className="px-4 py-2 text-gray-600 bg-gray-100 rounded-md hover:bg-gray-200 focus:outline-none focus:ring-2 focus:ring-gray-500 transition-colors"
                        disabled={loading}
                    >
                        Reset
                    </button>

                    <button
                        type="submit"
                        disabled={loading}
                        className="px-6 py-2 text-white bg-blue-600 rounded-md hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500 disabled:bg-blue-300 disabled:cursor-not-allowed transition-colors flex items-center"
                    >
                        {loading ? (
                            <>
                                <svg className="animate-spin -ml-1 mr-2 h-4 w-4 text-white" fill="none" viewBox="0 0 24 24">
                                    <circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4"></circle>
                                    <path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
                                </svg>
                                Creating...
                            </>
                        ) : (
                            'Create Warehouse'
                        )}
                    </button>
                </div>
            </form>

            <div className="mt-4 text-sm text-gray-500">
                <p>* Required fields</p>
            </div>
        </div>
    );
};

export default CreateWarehousePage;