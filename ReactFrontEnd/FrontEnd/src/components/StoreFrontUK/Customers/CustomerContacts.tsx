import type { ICustomerContact } from "../../../api/entities/ICustomer";

export default function CustomerContacts({customerContacts} : {customerContacts?: ICustomerContact[]}){
    if (!customerContacts) return;
    
    return(
        <ul>
        {
            customerContacts.map(cc => <li className="list-group-item"><strong>{cc.customerContactType.toString()}</strong><br />{cc.value} </li>)
        }
        </ul>
    )
    
}