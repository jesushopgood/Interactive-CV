import type { ICustomerAddress } from "../../../api/entities/ICustomer";

export default function CustomerAddresses({addresses} : {addresses? : ICustomerAddress[]}){
    
    if (!addresses) return;
    
    return (
        <ul className="list-unstyled">
            {   addresses?.map(a => 
                <li className="list-group-numbered">{a.line1}<br/> {a.line2}<br/>{a.postcode}</li>)
            }
        </ul>
    )
}