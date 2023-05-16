import Login from "./components/login";
import {Routes, Route} from "react-router-dom"
import Register from "./components/register";


function App() {
  return (
    <>
      <div className="main-container">
        <Routes>
          <Route path="/" element={<Login/>}/>
          <Route path="/register" element={<Register/>}/>
        </Routes>
      </div>
    </>
   
  );
}

export default App;
