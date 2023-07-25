import React from "react";
import FormControl from '@mui/material/FormControl';

class FormInput extends React.Component{
    render(){
        return(
        <div style={{margin:"20px"}}>
    <FormControl>
      <input
        type="text"
        name="value"
        id="name"
        placeholder="Full name"
        aria-describedby="my-helper-text"
      />
    </FormControl>
    </div>
        )
    }
}
export default FormInput;
/*const FormInput = () => {

  return (
    <div>
    <form>
      <input
        type="text"
        name="value"
        id="name"
        placeholder="Full name"
      />
    </form>
    </div>
  );
};*/



