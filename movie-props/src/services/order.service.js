import { axiosInstance } from "../config/https";

class OrderService {
	constructor() {}

	async createOrder(data) {
		return await axiosInstance.post("/Order/createOrder", data);
	}

	async getMyOrders() {
		return await axiosInstance.get("/Order/getMyOrders");
	}

	async getAllOrders() {
		return await axiosInstance.get("/Order/getAllOrders");
	}

	async getOrderedItemsByUser() {
		return await axiosInstance.get("/Order/getOrderedItemsByUserEmail");
	}

	async cancelOrder(id) {
		return await axiosInstance.post(`/Order/CancelOrder/${id}`);
	}
}

export default OrderService;
