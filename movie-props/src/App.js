import Login from "./components/login";
import { Routes, Route } from "react-router-dom";
import Register from "./components/register";
import Dashboard from "./components/dashboard";
import Navigation from "./components/navigation-comp/navigation";
import AddArticle from "./components/article-comp/addArticle";
import MainShop from "./components/mainShop";
import MyCart from "./components/myCart-comp/myCart";
import { useState } from "react";

function App() {
  const [userEmail, setUserEmail] = useState("");

  const onLogIn = (email) => {
    setUserEmail(localStorage["email"]);
  };

  return (
    <>
      <div className="main-container">
        <Navigation userEmail={userEmail} />
        <h1>Ovo je env file: {process.env.REACT_APP_SERVER_URL} jj</h1>
        <Routes>
          <Route path="" element={<Dashboard />} />
          <Route path="login" element={<Login onLogIn={onLogIn} />} />
          <Route path="register" element={<Register />} />
          <Route path="add-article" element={<AddArticle />} />
          <Route path="main-shop" element={<MainShop />} />
          <Route path="my-cart" element={<MyCart />} />
        </Routes>
      </div>
    </>
  );
}

export default App;
