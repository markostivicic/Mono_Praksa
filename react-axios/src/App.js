import AddCustomer from "./components/AddCustomer";
import UpdateCustomer from "./components/UpdateCustomer";
import CustomerList from "./components/CustomerList";
import React, { useEffect, useState } from "react";
import axios from "axios";
import API from "./api";

function App() {
  const [customers, setCustomers] = useState([]);
  const [editData, setEditData] = useState(null);

  const fetchCustomers = () => {
    axios.get("https://localhost:44348/api/customer").then((response) => {
      console.log(response.data);
      setCustomers(response.data.Item1);
    });
  };

  useEffect(() => {
    fetchCustomers();
  }, []);
  async function handleDelete(id) {
    await API.delete(`/${id}`)
      .then((response) => {
        console.log(response);
        console.log(response.data);
      })
      .catch((error) => {
        console.log(error.response.data);
      });
    fetchCustomers();
  }
  /*async function getAccountById(id) {
    try {
      await axios
        .get("https://localhost:44348/api/customer/" + id)
        .then((response) => {
          setEditData(response.data);
        });
    } catch (error) {
      console.log(error);
    }
  }*/

  function handleEdit(customer) {
    setEditData(customer);
    console.log(customer);
  }

  return (
    <div>
      <CustomerList
        fetchCustomers={fetchCustomers}
        customers={customers}
        handleDelete={handleDelete}
        onEdit={handleEdit}
      />
      <AddCustomer fetchCustomers={fetchCustomers} />
      <UpdateCustomer
        firstName={editData ? editData.FirstName : ""}
        lastName={editData ? editData.LastName : ""}
        id={editData ? editData.Id : ""}
        fetchCustomers={fetchCustomers}
      />
    </div>
  );
}

export default App;
