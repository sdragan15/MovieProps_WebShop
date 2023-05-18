import Login from "./components/login";
import { Routes, Route } from "react-router-dom";
import Register from "./components/register";
import Dashboard from "./components/dashboard";
import Navigation from "./components/navigation-comp/navigation";
import AddArticle from "./components/article-comp/addArticle";

function App() {
  return (
    <>
      <div className="main-container">
        <Routes>
          <Route path="" element={<Login />} />
          <Route path="register" element={<Register />} />
          <Route path="dashboard" element={<Dashboard />} />
          <Route path="add-article" element={<AddArticle />} />
        </Routes>
      </div>
    </>
  );
}

export default App;
