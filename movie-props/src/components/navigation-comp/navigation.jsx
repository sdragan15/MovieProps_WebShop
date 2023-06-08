import { Link } from "react-router-dom";
import styles from "../../styles/navigation.css";
import NavigationItem from "./navigationItem";
import { useEffect, useState } from "react";

function Navigation({ user }) {
  return (
    <>
      <div className="navigation-wrapper">
        <div className="navigation-left">
          {user && <img className="nav-image" src={user.image}></img>}
          {user && <NavigationItem item={"Profile"} path={"profile"} />}
          {!user && <NavigationItem item={"Log in"} path={"login"} />}
          {!user && <NavigationItem item={"Register"} path={"register"} />}
          {user && <NavigationItem item={"My Cart"} path={"my-cart"} />}
          {user && <NavigationItem item={"My Product"} path={"my-product"} />}
          <NavigationItem item={"Shop"} path={"main-shop"} />
        </div>
        <div className="navigation-header">
          <Link to={""}>Movie Props</Link>
        </div>
        <div className="navigation-right">
          {user && (
            <NavigationItem
              className="logout-wrapper"
              item={"Log out"}
              path={"logout"}
            />
          )}
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
