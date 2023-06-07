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
}

export default ItemService;
