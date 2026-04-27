import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Home from "../../screens/Home";
import Medicines from "../../screens/Medicines";
import AddMedicine from "../../screens/AddMedicine";
import NavBar from "./NavBar";

const NavRoutes = () => {
    return (
        <Router>
            <NavBar />
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/medicines" element={<Medicines />} />
                <Route path="/add-medicine" element={<AddMedicine />} />
            </Routes>
        </Router>
    )
}

export default NavRoutes;