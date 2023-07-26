import React from "react";

import API from "../api";

function UpdateCustomer(props) {
  async function submitForm(e) {
    e.preventDefault();
    console.log(e);
    const state = {
      firstName: e.target.elements.firstName.value,
      lastName: e.target.elements.lastName.value,
    };
    console.log(state);
    if (props.id !== "") {
      await API.put(`/${props.id}`, state).then((res) => {
        console.log(res);
        console.log(res.data);
      });
      props.fetchCustomers();
    }
  }

  return (
    <div>
      <p>Edit Customer</p>
      <div>
        <form onSubmit={submitForm}>
          <label>
            Customer Name:
            <input
              type="text"
              name="firstName"
              placeholder="firstName"
              defaultValue={props.firstName}
            />
            <input
              type="text"
              name="lastName"
              placeholder="lastName"
              defaultValue={props.lastName}
            />
          </label>
          <button type="submit">Update</button>
        </form>
      </div>
    </div>
  );
}

export default UpdateCustomer;
