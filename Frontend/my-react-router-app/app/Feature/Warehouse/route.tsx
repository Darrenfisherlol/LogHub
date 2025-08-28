import { BrowserRouter, Routes, Route } from "react-router-dom";
import WarehouseDetails from "./Components/WarehouseDetails";
import WarehouseList from "./Components/WarehouseList";

function App() {
    return (
        <BrowserRouter>
            <Routes>
                {/* list page showing all warehouses */}
                <Route path="/warehouses" element={<WarehouseList />} />

                {/* details page for one warehouse */}
                <Route path="/warehouses/:id" element={<WarehouseDetails />} />
            </Routes>
        </BrowserRouter>
    );
}

export default App;
