import axios from "axios";

export const axiosInstance = axios.create({
  baseURL: process.env.REACT_APP_SERVER_URL,
});

axiosInstance.interceptors.request.use(
  async (config) => {
    const token = localStorage["token"];
    if (token) {
      config.headers.Authorization = "Bearer " + token;
    }
    return config;
  },
  function (error) {
    return Promise.reject(error);
  }
);

axiosInstance.interceptors.response.use(
  function (response) {
    return response;
  },
  function (error) {
    return Promise.reject(error);
  }
);
