import { Link } from "react-router-dom";
import styles from "../../styles/navigation.css";
import NavigationItem from "./navigationItem";
import { useState } from "react";

function Navigation({ userEmail }) {
  return (
    <>
      <div className="navigation-wrapper">
        <div className="navigation-left">
          {userEmail && <NavigationItem item={"Profile"} path={"profile"} />}
          {!userEmail && <NavigationItem item={"Log in"} path={"login"} />}
          {!userEmail && <NavigationItem item={"Register"} path={"register"} />}
          {userEmail && <NavigationItem item={"My Cart"} path={"my-cart"} />}
        </div>
        <div className="navigation-header">
          <Link to={""}>Movie Props</Link>
        </div>
        <div className="navigation-right">
          <NavigationItem item={"Shop"} path={"main-shop"} />
          {userEmail && <NavigationItem item={"Log out"} path={"logout"} />}
          {/* <NavigationItem item={"New Orders"} />
          <NavigationItem item={"My Orders"} />
          <NavigationItem item={"All Orders"} /> */}
        </div>
        {/* <NavigationItem item={"Add Article"} path={"add-article"} />
        <NavigationItem item={"New Order"} />
        <NavigationItem item={"Orders History"} /> */}
      </div>
    </>
  );
}

export default Navigation;
