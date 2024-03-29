import Login from "./components/login";
import { Routes, Route, useNavigate } from "react-router-dom";
import Register from "./components/register";
import Dashboard from "./components/dashboard";
import Navigation from "./components/navigation-comp/navigation";
import MainShop from "./components/mainShop";
import MyCart from "./components/myCart-comp/myCart";
import { useEffect, useState } from "react";
import AddProduct from "./components/addProduct-comp/addProduct";
import LogOut from "./components/logout";
import UserService from "./services/user.service";
import { UserModel } from "./models/user.model";
import Sellers from "./components/sellers-comp/sellers";
import NotApproved from "./components/notApproved";
import Profile from "./components/profile";
import Toastr from "./helpers/toastr";
import MyOrders from "./components/myOrders";
import AllOrders from "./components/allOrders";
import OrderedItems from "./components/orderedItems";
import { RoleModel } from "./models/role.model";

function App() {
	const userService = new UserService();
	const navigate = useNavigate();
	const [user, setUser] = useState(null);
	let routes = <></>;
	const role = new RoleModel();

	useEffect(() => {
		if (
			localStorage["user"] != undefined &&
			localStorage["user"] != "" &&
			localStorage["user"] != null
		) {
			let userTemp = new UserModel();
			userTemp = JSON.parse(localStorage["user"]);
			setUser(userTemp);
		}
	}, []);

	const onLogIn = () => {
		userService
			.get()
			.then((response) => {
				if (response.status == 200) {
					setUser(response.data.data);
					localStorage["user"] = JSON.stringify(response.data.data);
				} else {
					alert("failed");
				}
			})
			.catch((error) => {
				console.log(error);
			});
	};

	const onLogOut = () => {
		localStorage.clear();
		setUser(null);
		navigate("/");
	};

	if (user == null) {
		routes = (
			<>
				<Route path="" element={<Dashboard />} />
				<Route path="login" element={<Login onLogIn={onLogIn} />} />
				<Route path="register" element={<Register />} />
				<Route path="main-shop" element={<MainShop />} />
			</>
		);
	} else if (user.role == role.admin) {
		routes = (
			<>
				<Route path="" element={<Dashboard />} />
				<Route path="main-shop" element={<MainShop />} />
				<Route path="logout" element={<LogOut onLogOut={onLogOut} />} />
				<Route path="sellers" element={<Sellers />} />
				<Route path="profile" element={<Profile />} />
				<Route path="all-orders" element={<AllOrders />} />
			</>
		);
	} else if (user.role == role.buyer) {
		routes = (
			<>
				<Route path="" element={<Dashboard />} />
				<Route path="main-shop" element={<MainShop />} />
				<Route path="my-cart" element={<MyCart />} />
				<Route path="logout" element={<LogOut onLogOut={onLogOut} />} />
				<Route path="profile" element={<Profile />} />
				<Route path="my-orders" element={<MyOrders />} />
				<Route path="ordered-items" element={<OrderedItems />} />
			</>
		);
	} else if (user.role == role.seller) {
		routes = (
			<>
				<Route path="" element={<Dashboard />} />
				<Route path="main-shop" element={<MainShop />} />
				<Route path="my-cart" element={<MyCart />} />
				<Route path="my-product" element={<AddProduct />} />
				<Route path="logout" element={<LogOut onLogOut={onLogOut} />} />
				<Route path="profile" element={<Profile />} />
				<Route path="my-orders" element={<MyOrders />} />
				<Route path="ordered-items" element={<OrderedItems />} />
				<Route
					path="pending"
					element={<NotApproved text={"Waiting for approval from admin..."} />}
				/>
				<Route
					path="rejected"
					element={<NotApproved text={"You are not approved from admin!"} />}
				/>
			</>
		);
	}

	return (
		<>
			<div className="main-container">
				<div className="main-overlay">
					<Toastr />
					<Navigation user={user} />
					<Routes>
						{routes}
						<Route path="*" element={<NoRoute />} />
					</Routes>
				</div>
			</div>
		</>
	);
}

function NoRoute() {
	window.location.href = "https://localhost:3000";
	return;
}

export default App;
