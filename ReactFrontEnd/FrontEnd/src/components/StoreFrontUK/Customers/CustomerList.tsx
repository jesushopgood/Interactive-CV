import { useQuery } from "@tanstack/react-query";
import { getCustomers } from "../../../api/customers";
import type { ICustomer } from "../../../api/entities/ICustomer";

export function CustomerList({onSelectCustomer} : {onSelectCustomer? : (customerId: string) => void}) {
  const { data, isLoading, error } = useQuery({
    queryKey: ["customers"],
    queryFn: getCustomers,
  });

  if (isLoading) return <p>Loading...</p>;
  if (error) return <p>Something went wrong {error.message}</p>;

  return ( 
    <table className="table table-borderless">
        <thead>
          <tr>
            <th>Title</th>
            <th>First Name</th>
            <th>Surname</th>
            <th>Email Address</th>
          </tr>
        </thead>
        <tbody>
        { data.map((c: ICustomer) =>
          <tr key={c.customerId} onClick={() => onSelectCustomer!(c.customerId)}>
            <td>{c.customerTitle}</td>
            <td>{c.customerFirstName}</td>
            <td>{c.customerSurname}</td>
            <td>{c.customerEmailAddress}</td>
          </tr>
          )
        }
        </tbody>  
    </table>
  );
}
