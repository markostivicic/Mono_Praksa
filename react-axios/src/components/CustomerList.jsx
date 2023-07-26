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
            <th>First</th>
            <th>Last</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
          {props.customers.map((customer) => (
            <tr key={customer.Id}>
              <td>{customer.FirstName}</td>
              <td>{customer.LastName}</td>
              <td>
                <button onClick={() => props.handleDelete(customer.Id)}>
                  X
                </button>
                <button
                  onClick={() => navigate(`/updatecustomer/${customer.Id}`)}
                >
                  edit
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}
