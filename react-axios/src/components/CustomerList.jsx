import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Link } from "react-router-dom";
import axios from "axios";
import API from "../api";

export default function CustomerList(props) {
  const navigate = useNavigate();
  return (
    <>
      <p>Costumer List</p>
      <p>
        <button onClick={() => props.fetchCustomers()}>Fetch Customers</button>
      </p>
      <table>
        <thead>
          <tr>
            <th>Name</th>
            {props.userInfo !== null && props.userInfo.role === "Admin" ? (
              <th>Action</th>
            ) : (
              ""
            )}
          </tr>
        </thead>
        <tbody>
          {props.customers.map((customer) => (
            <tr key={customer.id}>
              <td>{customer.name}</td>
              {props.userInfo !== null && props.userInfo.role === "Admin" ? (
                <td>
                  <button onClick={() => props.handleDelete(customer.id)}>
                    X
                  </button>
                  <button
                    onClick={() => navigate(`/updatecustomer/${customer.id}`)}
                  >
                    edit
                  </button>
                </td>
              ) : (
                ""
              )}
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}
