import { OrderType } from "../models/orders.model";
import "../styles/order.css";

function Order({ orders }) {
	const orderType = new OrderType();

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
							<span>Delivered</span>
						</th>
						<th>
							<span>Status</span>
						</th>
						<th></th>
					</tr>
				</thead>
				<tbody className="order-tbody">
					{orders.map((order) => (
						<tr key={order.id}>
							<td>
								<span>{order.id}</span>
							</td>
							<td>
								<span>{order.products}</span>
							</td>
							<td>
								<span>{order.shipping}</span>
							</td>
							<td>
								<span>{order.total}</span>
							</td>
							<td>
								<span>{order.ordered}</span>
							</td>
							<td>
								<span>{order.delivered}</span>
							</td>
							<td>
								{order.orderType == orderType.canceled ? (
									<span className="order-canceled">Cancled</span>
								) : null}
								{order.orderType == orderType.delivered ? (
									<span className="order-delivered">Delivered</span>
								) : null}
								{order.orderType == orderType.ordered ? (
									<span className="order-delivering">Delivering</span>
								) : null}
							</td>
							<td className="order-cancel-td">
								<div className="order-cancel-btn">
									<button className="button">Cancel</button>
								</div>
							</td>
						</tr>
					))}
				</tbody>
			</table>
		</>
	);
}

export default Order;
