import { NavLink, Route, Routes } from "react-router-dom";
import AddCustomer from "./components/AddCustomer";
import Home from "./Home";
import UpdateCustomer from "./components/UpdateCustomer";
import "./App.css";

function App() {
  return (
    <>
      <nav>
        <ul>
          <li>
            <NavLink to="/">Home</NavLink>
          </li>
          <li>
            <NavLink to="/addcustomer">AddCustomer</NavLink>
          </li>
        </ul>
      </nav>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/addcustomer" element={<AddCustomer />} />
        <Route path="/updatecustomer/:id" element={<UpdateCustomer />} />
      </Routes>
    </>
  );
}
export default App;
