import React from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";

export default function LoginForm({ fetchUserInfo }) {
  const navigate = useNavigate();
  async function handleSubmit(e) {
    e.preventDefault();
    if (e.target.username.value === "" || e.target.password.value === "") {
      alert("Please enter username and password");
      return;
    }
    const userInfo = {
      username: e.target.username.value,
      password: e.target.password.value,
      grant_type: "password",
    };
    try {
      await axios
        .post("https://localhost:44345/login", userInfo, {
          headers: {
            "Content-Type": "application/x-www-form-urlencoded",
          },
        })
        .then((response) => {
          localStorage.setItem("token", JSON.stringify(response.data));
          fetchUserInfo();
          navigate("/");
        });
    } catch (e) {
      alert(e.response.data.error_description);
    }
  }
  return (
    <form onSubmit={handleSubmit}>
      <label htmlFor="username">Username:</label>
      <input type="text" name="username" id="username" />
      <label htmlFor="password">Password:</label>
      <input type="password" name="password" id="password" />
      <button type="submit" color="white">
        login
      </button>
    </form>
  );
}
