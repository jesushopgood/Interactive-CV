import type { ICustomerNote } from "../../../api/entities/ICustomer";

export default function CustomerNotes({customerNotes} : { customerNotes?: ICustomerNote[] }){

    if (!customerNotes) return;

    return (
        <ul className="list-unstyled">
            {
                customerNotes.map(cn => <li className="list-group-item">{cn.message}</li>)
            }
        </ul>
    )
}