import { OrderType } from "../models/orders.model";
import "../styles/order.css";

function Order({ orders, onClick, showCancel, cancel }) {
	const orderType = new OrderType();

	const handleCancel = (e, order) => {
		e.preventDefault();
		e.stopPropagation();
		cancel(order.id);
	};

	return (
		<>
			<table className="order-table">
				<thead className="order-thead">
					<tr>
						<th>
							<span>ID</span>
						</th>
						<th>
							<span>Products</span>
						</th>
						<th>
							<span>Shipping</span>
						</th>
						<th>
							<span>Total Price</span>
						</th>
						<th>
							<span>Ordered</span>
						</th>
						<th>
							<span>Deliver Time</span>
						</th>
						<th>
							<span>Status</span>
						</th>
						<th></th>
					</tr>
				</thead>
				<tbody className="order-tbody">
					{orders.map((order) => (
						<tr
							onClick={(e) => {
								onClick(e, order);
							}}
							key={order.id}
						>
							<td>
								<span>{order.id}</span>
							</td>
							<td>
								<span>${order.products}</span>
							</td>
							<td>
								<span>${order.shipping}</span>
							</td>
							<td>
								<span>${order.total}</span>
							</td>
							<td>
								<span>{order.ordered}</span>
							</td>
							<td>
								{order.orderType == orderType.canceled ? (
									<span>N/A</span>
								) : (
									<span>{order.delivered}</span>
								)}
							</td>
							<td>
								{order.orderType == orderType.canceled ? (
									<span className="order-canceled">Canceled</span>
								) : null}
								{order.orderType == orderType.delivered ? (
									<span className="order-delivered">Delivered</span>
								) : null}
								{order.orderType == orderType.ordered ? (
									<span className="order-delivering">Delivering</span>
								) : null}
							</td>
							<td className="order-cancel-td">
								{order.orderType == orderType.ordered && showCancel ? (
									<div className="order-cancel-btn">
										<button
											className="button order-cancel-btn-main"
											onClick={(event) => handleCancel(event, order)}
										>
											Cancel
										</button>
									</div>
								) : null}
							</td>
						</tr>
					))}
				</tbody>
			</table>
		</>
	);
}

export default Order;
