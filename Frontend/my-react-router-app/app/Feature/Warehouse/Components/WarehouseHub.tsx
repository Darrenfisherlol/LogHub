// In your main App.tsx
import React from 'react';
import CreateWarehousePage from './WarehouseCreate';

const WarehouseHub: React.FC = () => {
    return (
        <div className="App">
            <CreateWarehousePage />
        </div>
    );
};

export default WarehouseHub;