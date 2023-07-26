import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import axios from "axios";

import API from "../api";

function UpdateCustomer(props) {
  const [editData, setEditData] = useState(null);
  const navigate = useNavigate();
  const { id } = useParams();
  useEffect(() => {
    axios.get("https://localhost:44348/api/customer/" + id).then((response) => {
      setEditData(response.data);
      console.log(response);
    });
  }, []);

  async function submitForm(e) {
    e.preventDefault();
    console.log(e);
    const state = {
      firstName: e.target.elements.firstName.value,
      lastName: e.target.elements.lastName.value,
    };
    if (id !== "") {
      await API.put(`/${id}`, state).then((res) => {
        console.log(res);
        console.log(res.data);
      });
      navigate("/");
    }
  }

  return (
    <div>
      <p>Edit Customer</p>
      <div>
        <form onSubmit={submitForm}>
          <label>
            Customer Name:
            <input type="text" name="firstName" placeholder="firstName" />
            <input type="text" name="lastName" placeholder="lastName" />
          </label>
          <button type="submit">Update</button>
        </form>
      </div>
    </div>
  );
}

export default UpdateCustomer;
