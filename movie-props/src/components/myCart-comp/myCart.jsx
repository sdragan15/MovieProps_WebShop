import { useState } from "react";
import styles from "../../styles/myCart.css";
import CartItem from "./cartItem";
import { useEffect } from "react";
import ItemService from "../../services/item.service";
import { toast } from "react-toastify";
import { BalanceModel } from "../../models/balance.model";
import MyInput from "../input-comp/myInput";
import { OrdersModel } from "../../models/orders.model";
import OrderService from "../../services/order.service";
import { useNavigate } from "react-router-dom";

function MyCart() {
	const navigate = useNavigate();
	const itemService = new ItemService();
	const orderService = new OrderService();

	const [items, setItems] = useState([]);
	const [ballance, setBallance] = useState(new BalanceModel());
	const [orders, setOrders] = useState(new OrdersModel());

	const getItemIds = (items) => {
		let ids = [];
		if (items != null && items != []) {
			items.forEach((element) => {
				let temp = {
					id: element.id,
					count: element.count,
				};
				ids.push(temp);
			});
		}
		return ids;
	};

	const checkItems = (items) => {
		let updated = false;
		let data = {
			items: getItemIds(items),
		};
		itemService
			.getByIds(data)
			.then((response) => {
				if (response.status == 200) {
					let newItems = response.data.data.items;
					setBallance(response.data.data);
					console.log(response.data.data);
					items.forEach((item) => {
						newItems.forEach((newItem) => {
							if (newItem.id == item.id) {
								newItem.count = item.count;
								if (newItem.name != item.name) {
									console.log(newItem, item);
									updated = true;
								}
								if (newItem.description != item.description) {
									console.log(newItem, item);
									updated = true;
								}
								if (newItem.price != item.price) {
									console.log(newItem, item);
									updated = true;
								}
							}
						});

						if (updated) {
							toast.warning("Items are changed");
						}
					});
					setItems(response.data.data.items);
				} else {
					toast.error(response.data.message);
				}
			})
			.catch((error) => {
				toast.error(error.message);
			});
	};

	useEffect(() => {
		if (localStorage["items"] != "" && localStorage["items"] != undefined) {
			let temp = localStorage["items"];
			setItems(JSON.parse(temp));
			checkItems(JSON.parse(temp));
		}
		let user = JSON.parse(localStorage["user"]);
		setOrders((prevState) => ({
			...prevState,
			address: user.address,
		}));
	}, []);

	useEffect(() => {
		setOrders((prevState) => ({
			...prevState,
			items: items,
		}));
	}, [items]);

	const purchase = (e) => {
		e.preventDefault();

		orderService
			.createOrder(orders)
			.then((response) => {
				if (response.status == 200) {
					toast.success("Success");
					navigate("/");
					localStorage["items"] = "";
				} else {
					toast.error(response.data.message);
				}
			})
			.catch((error) => {
				toast.error(error.message);
			});
	};

	return (
		<>
			<div className="mycart-background"></div>
			<div className="cart-wrapper">
				<div className="cart-item-container">
					{items.map((item) => (
						<CartItem key={item.id} item={item} isBuyNo={true} />
					))}
				</div>
				<div className="cart-total">
					<table>
						<tbody>
							<tr className="cart-address-label">
								<th>Address:</th>
							</tr>
							<tr className="cart-address-input">
								<td colSpan={2}>
									<MyInput
										type={"text"}
										value={orders.address}
										onChange={(e) =>
											setOrders((prevState) => ({
												...prevState,
												address: e.target.value,
											}))
										}
									/>
								</td>
							</tr>
							<tr className="cart-side">
								<th>Products:</th>
								<td>{ballance.productsCost} rsd</td>
							</tr>
							<tr className="cart-side cart-bottom-border">
								<th>Shipping:</th>
								<td>{ballance.shipping} rsd</td>
							</tr>
							<tr className="cart-total-label">
								<th>Total:</th>
								<td>{ballance.total} rsd</td>
							</tr>
							<tr>
								<td colSpan={2}>
									<div className="cart-purchase">
										<button className="button cart-buy-btn" onClick={purchase}>
											Purchase
										</button>
									</div>
								</td>
							</tr>
						</tbody>
					</table>
				</div>
			</div>
		</>
	);
}

export default MyCart;
