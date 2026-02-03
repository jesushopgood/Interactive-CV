import { isCustomerAddress, toArray } from "../../../api/entities/ICustomer";

export default function CustomerAddresses({data} : {data? : unknown}){
    
    if (!data) return;
    const addresses = toArray(data, isCustomerAddress);
    
    return (
        <ul className="list-unstyled">
            {   addresses?.map((a, idx) => 
                <li key={idx} className="list-group-numbered">{a.line1} {a.postcode}</li>)
            }
        </ul>
    )
}