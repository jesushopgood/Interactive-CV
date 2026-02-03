/* eslint-disable react-hooks/exhaustive-deps */
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { createCustomer, getCustomer, updateCustomer } from "../../../api/customers";
import { emptyCustomer, type ICustomer } from "../../../api/entities/ICustomer";
import { useEffect, useState } from "react";
import ToggledReadOnlyInput from "../Common/ReadOnlyInput";

interface CustomerDetailProps
{
    entityId?: string | undefined;
    onLoaded?: (name: string) => void;
    onBackToResults?: () => void;
}

export default function CustomerDetail({entityId, onLoaded, onBackToResults} : CustomerDetailProps){
    const isNewCustomer = entityId === undefined;

    const [isEditOn, setIsEditOn] = useState(isNewCustomer);
    const [formData, setFormData] = useState<ICustomer>(emptyCustomer);    

    const { data, isLoading, error } = useQuery<ICustomer>({
        queryKey: ["customer", entityId],
        queryFn: ({ queryKey }) => getCustomer(queryKey[1] as string),
        enabled: !isNewCustomer
    });

    const queryClient = useQueryClient();

    const updateCustomerMutation = useMutation({
        mutationFn: (updated: ICustomer) => updateCustomer(updated),
        onSuccess: () => {
            queryClient.invalidateQueries({ queryKey: ["customer", entityId] });
        }
    });

    const createCustomerMutation = useMutation({
        mutationFn: (create: ICustomer) => createCustomer(create),
        onSuccess: () => {
            queryClient.invalidateQueries({ queryKey: ["customer", entityId] });
        }
    });

    const handleSaveClick = () => {
        setIsEditOn(prev => {
            const result = !prev;
            if (!result){
                if (isNewCustomer){
                    createCustomerMutation.mutate(formData);
                }
                else{
                    updateCustomerMutation.mutate(formData);
                }
            }   
            return result;
        });
    };

    
    // We notify when we've loaded so we can pass this up to the parent tab to give the tab 
    // the name of the customer
    useEffect(() => {
        if(data) {
            onLoaded!(`${data.customerName.firstName} ${data.customerName.surname}`);
            setFormData(data);
        }
    }, [data])

    if (isLoading) return <p>Loading...</p>;
    if (error) return <p>Something went wrong {error.message}</p>;
    
    console.log(data);
    
    return (
        <div className="container-fluid">
            <div className="d-flex justify-content-between mb-4">
                <button className={`btn ${isEditOn ? "btn-outline-danger" : "btn-outline-primary"} m-0`} 
                                            onClick={handleSaveClick}>{isEditOn || isNewCustomer ? "Save": "Edit"}</button>
                <button className="btn  btn-outline-primary m-0" onClick={onBackToResults}>Back To Results</button>
            </div>
            <table className="table table-borderless entity-table">
                <tbody>
                    <tr>
                        <td className="label-column">
                            <label className="form-label" htmlFor="customer-title">Customer Name</label>
                        </td>
                        <td>
                            <div>
                                <ToggledReadOnlyInput<ICustomer> id="customer-title" 
                                    isReadOnly={!isEditOn} 
                                    value={formData?.customerName.title}
                                    onEdit={(data:ICustomer) => setFormData(data)}
                                    formData={formData}
                                    fieldName="customerTitle" />
                            </div>
                            <div className="mt-2">
                                <ToggledReadOnlyInput<ICustomer> 
                                    isReadOnly={!isEditOn} 
                                    value={formData?.customerName.firstName}
                                    onEdit={(data:ICustomer) => setFormData(data)}
                                    formData={formData}
                                    fieldName="customerFirstName" />  
                            </div>
                            <div className="mt-2">
                                <ToggledReadOnlyInput<ICustomer> 
                                    isReadOnly={!isEditOn} 
                                    value={formData?.customerName.surname}
                                    onEdit={(data:ICustomer) => setFormData(data)}
                                    formData={formData}
                                    fieldName="customerSurname" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td className="label-column">
                            <label className="form-label" htmlFor="customer-email-address">Email Address</label>
                        </td>
                        <td>
                            <ToggledReadOnlyInput<ICustomer> 
                                isReadOnly={!isEditOn} 
                                value={formData?.customerEmailAddress}
                                onEdit={(data:ICustomer) => setFormData(data)}
                                formData={formData}
                                fieldName="customerEmailAddress" />
                        </td>    
                    </tr>
                    <tr>
                        <td>
                            <label className="form-label" htmlFor="customer-address">
                                Address{formData?.addresses && formData?.addresses.length > 1 ? "es" : ""}
                            </label>
                        </td>
                        <td>
                            <input id="customer-address" className="form-control" 
                                                value={formData?.addresses.map((val) => val.line1.concat(" ", val.line2, " ", val.postcode, "\n"))}/>
                        </td>     
                    </tr>
                    <tr>
                        <td>
                            <label className="form-label" htmlFor="customer-notes">Notes</label>
                        </td>
                        <td>
                            <input id="customer-notes" className="form-control" 
                                                value={formData?.customerNotes.map((val) => val.message.concat("\n"))} />
                        </td>     
                    </tr>
                    <tr>
                        <td>
                            <label htmlFor="customer-contacts" className="form-label">Contacts</label>
                        </td>
                        <td>
                            <input id="customer-contacts" className="form-control" 
                                            value={formData?.customerContacts.map((val) => val.customerContactType.concat(": ", val.value, "\n"))} />
                        </td>     
                    </tr>
                </tbody>
            </table>
        </div>
    )    
}