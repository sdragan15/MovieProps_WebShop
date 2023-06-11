import { useEffect, useState } from "react";
import OrderService from "../services/order.service";
import styles from "../styles/myOrders.module.css";
import Order from "./order";
import { toast } from "react-toastify";
import Item from "./items-comp/item";
import CartItem from "./myCart-comp/cartItem";
import OrderModal from "./modals-comp/orderModal";

function MyOrders() {
	const orderService = new OrderService();

	const [orders, setOrders] = useState([]);
	const [selectedOrder, setSelectedOrder] = useState([]);
	const [showModal, setShowModal] = useState(false);

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

	const orderClick = (e, order) => {
		setSelectedOrder(order);
		setShowModal(true);
	};

	return (
		<>
			<div className={styles.backgroundWrapper}>
				<div className={styles.background}></div>
			</div>

			<div className={styles.mainWrapper}>
				<div className={styles.container}>
					<Order orders={orders} onClick={orderClick} />
				</div>
			</div>
			{showModal && (
				<OrderModal items={selectedOrder.items} isOpen={setShowModal} />
			)}
		</>
	);
}

export default MyOrders;
