import { useQuery } from "@tanstack/react-query";
import { getCustomer } from "../../../api/customers";
import type { ICustomer } from "../../../api/entities/ICustomer";

export default function CustomerDetail({customerId} : {customerId?: string }){
    const { data, isLoading, error } = useQuery<ICustomer>({
        queryKey: ["customer", customerId],
        queryFn: ({ queryKey }) => getCustomer(queryKey[1] as string),
    });

    if (isLoading) return <p>Loading...</p>;
    if (error) return <p>Something went wrong {error.message}</p>;

    return (
        <p>{data?.customerId} {data?.customerSurname}</p>
    )    
}