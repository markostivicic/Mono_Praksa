import React from "react";
import LoginForm from "./LoginForm";
import { useEffect } from "react";
import { useNavigate } from "react-router-dom";

export default function Login({ fetchUserInfo }) {
  const navigate = useNavigate();
  useEffect(() => {
    if (localStorage.getItem("token") !== null) {
      navigate("/");
    }
    fetchUserInfo();
  }, []);
  return (
    <div className="login">
      <div className="title">Login</div>
      <LoginForm fetchUserInfo={fetchUserInfo} />
    </div>
  );
}
