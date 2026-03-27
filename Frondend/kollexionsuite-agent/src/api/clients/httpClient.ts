import axios from "axios";

const httpClient = axios.create({
  baseURL: import.meta.env.VITE_BFF_URL || "http://localhost:5000/bff",
  withCredentials: true,
});

httpClient.interceptors.response.use(
  (response) => response,
  (error) => {
    if (error.response?.status === 401) {
      console.error("Unauthorized – redirect to login");
    }
    return Promise.reject(error);
  }
);

export default httpClient;
