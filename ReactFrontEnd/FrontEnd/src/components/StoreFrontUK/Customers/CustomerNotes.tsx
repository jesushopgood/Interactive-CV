import dayjs from "dayjs";
import { isCustomerNote, toArray } from "../../../api/entities/ICustomer";

export default function CustomerNotes(data: {data?: unknown}){
    if (!data) return;
    const customerNotes = toArray(data.data, isCustomerNote);
    
    return (
        <table className="table table-borderless">
        <thead>
            <tr>
                <td><strong>Date Received</strong></td>
                <td><strong>Message</strong></td>
            </tr>
        </thead>
        <tbody>
            {
                customerNotes.map((cn, idx) => 
                    <tr key={idx}>
                        <td>{dayjs(cn.messageDate).format("YYYY-MM-DD hh:mm")}</td>
                        <td>{cn.message}</td>
                    </tr>
                )
            }
        </tbody>   
        </table> 
    )
}