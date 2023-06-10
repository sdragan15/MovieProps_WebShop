import { useEffect, useState } from "react";
import OrderService from "../services/order.service";
import styles from "../styles/myOrders.module.css";
import Order from "./order";
import { toast } from "react-toastify";

function MyOrders() {
	const orderService = new OrderService();

	const [orders, setOrders] = useState([]);

	const getOrders = () => {
		orderService
			.getMyOrders()
			.then((response) => {
				if (response.status == 200) {
					console.log(response.data.data);
					setOrders(response.data.data);
				} else {
					toast.error(response.data.message);
				}
			})
			.catch((error) => {
				toast.error(error.message);
			});
	};

	useEffect(() => {
		getOrders();
	}, []);

	return (
		<>
			<div className={styles.mainWrapper}>
				<div className={styles.container}>
					<Order orders={orders} />
				</div>
			</div>
		</>
	);
}

export default MyOrders;
