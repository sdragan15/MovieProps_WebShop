import { axiosInstance } from "../config/https";

class ItemService {
  constructor() {}

  async getAll() {
    return await axiosInstance.get("/Items/GetAll");
  }
}

export default ItemService;
