import { NavLink, Route, Routes } from "react-router-dom";
import AddCustomer from "./components/AddCustomer";
import Home from "./Home";
import UpdateCustomer from "./components/UpdateCustomer";
import "./App.css";
import { useState, useEffect } from "react";
import Login from "./components/Login";

function App() {
  const [userInfo, setUserInfo] = useState(
    JSON.parse(localStorage.getItem("token"))
  );

  useEffect(() => {
    fetchUserInfo();
  }, []);

  function fetchUserInfo() {
    const storedToken = JSON.parse(localStorage.getItem("token"));
    setUserInfo(storedToken);
  }

  console.log(userInfo);

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
        <Route path="/" element={<Home userInfo={userInfo} />} />
        <Route
          path="/addcustomer"
          element={<AddCustomer userInfo={userInfo} />}
        />
        <Route
          path="/updatecustomer/:id"
          element={<UpdateCustomer userInfo={userInfo} />}
        />
        <Route
          path="/login"
          element={<Login fetchUserInfo={fetchUserInfo} />}
        />
      </Routes>
    </>
  );
}
export default App;
