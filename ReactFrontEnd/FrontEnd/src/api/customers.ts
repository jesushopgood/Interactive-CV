import { customerApi } from "./axiosClient";
import type { ICustomer } from "./entities/ICustomer";
import type { IPageSortFilter } from "./entities/IPageSortFilter";

export const getCustomers = async () => {
  const response = await customerApi.get("/api/Customer");
  return response.data;
};

export const getCustomer = async (customerId: string) => {
  const response = await customerApi.get(`/api/Customer/${customerId}`);
  return response.data;
};

export const postCustomerFilter = async (pageSortFilter: IPageSortFilter) => {
  const response = await customerApi.post("api/Customer/filters", pageSortFilter);
  return response.data;
}

export const updateCustomer = async(data: ICustomer) => {
  const response = await customerApi.put("api/Customer", data);
  return response.data;
}

