import { axiosInstance } from "../config/https";

class OrderService {
	constructor() {}

	async createOrder(data) {
		return await axiosInstance.post("/Order/createOrder", data);
	}

	async getMyOrders() {
		return await axiosInstance.get("/Order/getMyOrders");
	}
}

export default OrderService;
