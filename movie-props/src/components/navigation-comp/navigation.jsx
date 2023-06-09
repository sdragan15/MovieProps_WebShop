import { Link } from "react-router-dom";
import styles from "../../styles/navigation.css";
import NavigationItem from "./navigationItem";
import { useEffect, useState } from "react";
import { RoleModel } from "../../models/role.model";
import { UserStatus } from "../../models/user-status.model";

function Navigation({ user }) {
	const role = new RoleModel();
	const userStatus = new UserStatus();

	let nav = <></>;
	let approved = <></>;

	if (user == null || user == undefined || user == "") {
		nav = (
			<>
				<NavigationItem item={"Log in"} path={"login"} />
				<NavigationItem item={"Register"} path={"register"} />
				<NavigationItem item={"Shop"} path={"main-shop"} />
			</>
		);
	} else if (user.role == role.admin) {
		nav = (
			<>
				<img className="nav-image" src={user.image}></img>
				<NavigationItem item={"Profile"} path={"profile"} />
				<NavigationItem item={"Sellers"} path={"sellers"} />
				<NavigationItem item={"My Cart"} path={"my-cart"} />
				<NavigationItem item={"My Products"} path={"my-product"} />
				<NavigationItem item={"Shop"} path={"main-shop"} />
			</>
		);
	} else if (user.role == role.seller) {
		if (user.status == userStatus.Approved) {
			approved = (
				<>
					<NavigationItem item={"My Products"} path={"my-product"} />
				</>
			);
		} else if (user.status == userStatus.Pending) {
			approved = (
				<>
					<NavigationItem item={"My Products"} path={"pending"} />
				</>
			);
		} else if (user.status == userStatus.Rejected) {
			approved = (
				<>
					<NavigationItem item={"My Products"} path={"rejected"} />
				</>
			);
		}

		nav = (
			<>
				<img className="nav-image" src={user.image}></img>
				<NavigationItem item={"Profile"} path={"profile"} />
				<NavigationItem item={"My Cart"} path={"my-cart"} />
				{approved}
				<NavigationItem item={"Shop"} path={"main-shop"} />
			</>
		);
	} else if (user.role == role.buyer) {
		nav = (
			<>
				<img className="nav-image" src={user.image}></img>
				<NavigationItem item={"Profile"} path={"profile"} />
				<NavigationItem item={"My Cart"} path={"my-cart"} />
				<NavigationItem item={"Shop"} path={"main-shop"} />
			</>
		);
	}

	return (
		<>
			<div className="navigation-wrapper">
				<div className="navigation-left">{nav}</div>
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
