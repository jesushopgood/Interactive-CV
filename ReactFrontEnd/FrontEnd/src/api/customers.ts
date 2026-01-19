import { customerApi } from "./axiosClient";

export const getCustomers = async () => {
  const response = await customerApi.get("/api/Customer");
  return response.data;
};

export const getCustomer = async (customerId: string) => {
  const response = await customerApi.get(`/api/Customer/${customerId}`);
  return response.data;
};

