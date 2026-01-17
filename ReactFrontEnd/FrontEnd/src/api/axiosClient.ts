import axios from "axios";

export const customerApi = axios.create({
  baseURL: "http://localhost:5000", // point to Customer Service or whichever service
  timeout: 5000,
});

customerApi.interceptors.request.use((config) => {
  config.headers["X-Request-ID"] = crypto.randomUUID();
  return config;
});

customerApi.interceptors.response.use(
  async (res) => {
    return res;
  },
  async (err) => {
    console.error("API error:", err);
    throw err;
  }
);


