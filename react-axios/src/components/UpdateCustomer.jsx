import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";

import API from "../api";

function UpdateCustomer({ userInfo }) {
  const [editData, setEditData] = useState(null);
  const navigate = useNavigate();
  const { id } = useParams();
  useEffect(() => {
    API.get(`/${id}`, {
      headers: {
        Authorization: "Bearer " + userInfo.access_token,
      },
    }).then((response) => {
      setEditData(response.data);
      console.log(response);
    });
  }, []);
  console.log(editData);
  async function submitForm(e) {
    e.preventDefault();
    console.log(e);
    const state = {
      name: e.target.elements.name.value,
    };
    if (id !== "") {
      await API.put(`/${id}`, state, {
        headers: {
          Authorization: "Bearer " + userInfo.access_token,
        },
      }).then((res) => {
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
            <input type="text" name="name" placeholder="name" />
          </label>
          <button type="submit">Update</button>
        </form>
      </div>
    </div>
  );
}

export default UpdateCustomer;
