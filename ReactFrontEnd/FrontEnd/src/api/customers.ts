import { customerApi } from "./axiosClient";

export const getCustomers = async () => {
  const response = await customerApi.get("/api/Customer");
  return response.data;
};
