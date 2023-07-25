import './App.css';

import ButtonFun from "./components/ButtonFun";
import FormInput from "./components/FormInput";
import TextFun from './components/TextFun';

function App() {


  function saveName(){
    const name = document.getElementById("name").value
    localStorage.setItem("name", name)
  }
  
  function getName(){
    document.getElementById("text").innerHTML = localStorage.getItem("name")
    document.getElementById("name").value = localStorage.getItem("name")
  }

  return (
    <div className="App">
      <FormInput />
      <ButtonFun onClick={saveName}  text="Save"/>
      <ButtonFun onClick={getName}  text="Get"/>
      <TextFun/>
    </div>
  );
}

export default App;
