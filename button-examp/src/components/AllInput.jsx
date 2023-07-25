const AllInput = () => {

    return (
      <div style={{margin:"20px"}}>
      <form >
        <input 
          type="text"
          name="value"
          id="name"
          placeholder="Full name"
        /><br></br>
        <input
          type="text"
          job="value"
          id="job"
          placeholder="Job"
        />
      </form>
      </div>
    );
  };

  export default AllInput;