import { useEffect, useState } from "react";
import OrderService from "../services/order.service";
import styles from "../styles/orderedItems.module.css";
import { useSearchParams } from "react-router-dom";
import { OrderType } from "../models/orders.model";

function OrderedItems() {
	const orderService = new OrderService();
	const orderType = new OrderType();

	const [items, setItems] = useState([]);

	const getItems = () => {
		orderService
			.getOrderedItemsByUser()
			.then((response) => {
				if (response.status == 200) {
					setItems(response.data.data);
				} else {
					alert("failed");
				}
			})
			.catch((error) => {
				console.log(error);
			});
	};

	useEffect(() => {
		getItems();
		console.log(items);
	}, []);

	return (
		<>
			<div className={styles.mainWrapper}>
				<table className="order-table">
					<thead className="order-thead">
						<tr>
							<th>
								<span>Product ID</span>
							</th>
							<th>
								<span>Name</span>
							</th>
							<th>
								<span>Ordered</span>
							</th>
							<th>
								<span>Delivery Time</span>
							</th>
							<th>
								<span>Price</span>
							</th>
							<th>
								<span>Count</span>
							</th>
							<th>
								<span>Status</span>
							</th>
							<th></th>
						</tr>
					</thead>
					<tbody className="order-tbody">
						{items.map((item) => (
							<tr key={item.id}>
								<td>
									<span>{item.id}</span>
								</td>
								<td>
									<span>{item.name}</span>
								</td>
								<td>
									<span>{item.ordered}</span>
								</td>
								<td>
									<span>{item.delivered}</span>
								</td>
								<td>
									<span>${item.price}</span>
								</td>
								<td>
									<span>{item.count}</span>
								</td>
								<td>
									{item.status == orderType.canceled ? (
										<span className="order-canceled">Cancled</span>
									) : null}
									{item.status == orderType.delivered ? (
										<span className="order-delivered">Delivered</span>
									) : null}
									{item.status == orderType.ordered ? (
										<span className="order-delivering">Delivering</span>
									) : null}
								</td>
							</tr>
						))}
					</tbody>
				</table>
			</div>
		</>
	);
}

export default OrderedItems;
