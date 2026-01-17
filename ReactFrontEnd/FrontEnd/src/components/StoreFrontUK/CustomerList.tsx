import { useQuery } from "@tanstack/react-query";
import { getCustomers } from "../../api/customers";
import type { ICustomer } from "../../api/entities/ICustomer";

export function CustomerList() {
  const { data, isLoading, error } = useQuery({
    queryKey: ["customers"],
    queryFn: getCustomers,
  });

  if (isLoading) return <p>Loading...</p>;
  if (error) return <p>Something went wrong {error.message}</p>;

  return (
    <ul>
      {data.map((c: ICustomer) => (
        <li key={c.customerId}>{c.customerName}</li>
      ))}
    </ul>
  );
}
