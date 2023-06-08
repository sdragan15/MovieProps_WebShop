import { LoginModel } from "../models/login.model";
import { axiosInstance } from "../config/https";

export class UserService {
  constructor() {}

  async register(formData) {
    return await axiosInstance.post("/User/Register", formData, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    });
  }

  async get() {
    return await axiosInstance.get("/User/Get");
  }

  async getAllItems() {
    return await axiosInstance.get("/User/GetAllItems");
  }
}

export default UserService;
