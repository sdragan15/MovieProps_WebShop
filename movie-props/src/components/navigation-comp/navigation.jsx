import styles from "../../styles/navigation.css";
import NavigationItem from "./navigationItem";

function Navigation() {
  return (
    <>
      <div className="navigation-wrapper">
        <NavigationItem item={"Profile"} />
        <NavigationItem item={"Add Article"} path={"add-article"} />
        <NavigationItem item={"New Order"} />
        <NavigationItem item={"Orders History"} />
        <NavigationItem item={"New Orders"} />
        <NavigationItem item={"My Orders"} />
        <NavigationItem item={"All Orders"} />
      </div>
    </>
  );
}

export default Navigation;
