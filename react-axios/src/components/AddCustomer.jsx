import { useNavigate } from "react-router-dom";
import API from "../api";

function AddCustomer({ userInfo }) {
  const navigate = useNavigate();
  const submitForm = (e) => {
    e.preventDefault();
    const form = e.target;
    console.log(form.elements);
    const name = form.elements["Name"];
    const newCustomer = {
      Name: name.value,
    };
    API.post("", newCustomer, {
      headers: {
        Authorization: "Bearer " + userInfo.access_token,
      },
    }).then((res) => {
      console.log(res);
      console.log(res.data);
    });
    navigate("/");
  };

  return (
    <div>
      <p>Add Customer</p>
      <div>
        <form onSubmit={submitForm}>
          <label>
            First Name:
            <input id="Name" type="text" name="Name" />
          </label>
          <button type="submit">Add</button>
        </form>
      </div>
    </div>
  );
}

export default AddCustomer;
