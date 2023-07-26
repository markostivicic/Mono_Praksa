import axios from "axios";

function AddCustomer(props) {
  const submitForm = (e) => {
    e.preventDefault();
    const form = e.target;
    console.log(form.elements);
    const firstName = form.elements["FirstName"];
    const lastName = form.elements["LastName"];
    const newCustomer = {
      FirstName: firstName.value,
      LastName: lastName.value,
    };
    axios
      .post("https://localhost:44348/api/customer", newCustomer)
      .then((res) => {
        console.log(res);
        console.log(res.data);
      });
    props.fetchCustomers();
  };

  return (
    <div>
      <p>Add Customer</p>
      <div>
        <form onSubmit={submitForm}>
          <label>
            First Name:
            <input id="FirstName" type="text" name="FirstName" />
            Second Name:
            <input id="LastName" type="text" name="LastName" />
          </label>
          <button type="submit" onClick={() => props.fetchCustomers()}>
            Add
          </button>
        </form>
      </div>
    </div>
  );
}

export default AddCustomer;
