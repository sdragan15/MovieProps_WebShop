import { axiosInstance } from "../config/https";

class ItemService {
	constructor() {}

	async getAll() {
		return await axiosInstance.get("/Items/GetAll");
	}

	async addItem(formData) {
		return await axiosInstance.post("/Items/Add", formData, {
			headers: {
				"Content-Type": "multipart/form-data",
			},
		});
	}

	async updateItem(formData) {
		return await axiosInstance.post("/Items/Update", formData, {
			headers: {
				"Content-Type": "multipart/form-data",
			},
		});
	}

	async deleteItem(id) {
		return await axiosInstance.post(`/Items/Delete/${id}`);
	}

	async getByIds(data) {
		return await axiosInstance.post("/Items/getItemsByIds", data);
	}
}

export default ItemService;
