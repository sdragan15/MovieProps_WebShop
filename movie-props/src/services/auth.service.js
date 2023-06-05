import { LoginModel } from "../models/login.model";
import { axiosInstance } from "../config/https";

export class AuthService {
  constructor() {}

  async login(data) {
    return await axiosInstance.post("/Auth/Login", data);
  }
}

export default AuthService;
