import CustomerList from "./components/CustomerList";
import React, { useEffect, useState } from "react";
import API from "./api";
import { useNavigate } from "react-router-dom";

function Home({ userInfo }) {
  const [customers, setCustomers] = useState([]);
  const [editData, setEditData] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    if (userInfo === null) {
      navigate("/login");
    }
  }, []);
  const fetchCustomers = () => {
    API.get("", {
      headers: {
        Authorization: "Bearer " + userInfo.access_token,
      },
    }).then((response) => {
      console.log(response.data);
      setCustomers(response.data.items);
    });
  };
  console.log(editData);
  useEffect(() => {
    fetchCustomers();
  }, []);
  async function handleDelete(id) {
    await API.delete(`/toggle/${id}`, {
      headers: {
        Authorization: "Bearer " + userInfo.access_token,
      },
    })
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
        userInfo={userInfo}
      />
      <button onClick={() => navigate(`/addcustomer`)}>Add</button>
    </div>
  );
}

export default Home;
