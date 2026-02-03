import { isCustomerContact, toArray } from "../../../api/entities/ICustomer";

export default function CustomerContacts({data} : {data?: unknown}){
    
    if (!data) return;
    const contacts = toArray(data, isCustomerContact);
    
    return(
        <table className="table table-bordered mt-2">
            <thead>
                <tr>
                    <td><strong>Contact Type</strong></td>
                    <td><strong>Value</strong></td>
                </tr>
            </thead>
            <tbody className="w-50">
                {
                    contacts.map((cc,idx) => 
                        <tr key={idx}>
                            <td className="w-25">{cc.customerContactType.toString()}</td>
                            <td>{cc.value}</td>
                        </tr>
                    )
                }
                
            </tbody>
        </table>
    )
}