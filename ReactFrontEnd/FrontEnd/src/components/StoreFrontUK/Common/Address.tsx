import { isCustomerAddress, toArray } from "../../../api/entities/ICustomer";


export default function Address(data: {data: unknown}){
    if(!data) return;

    const addresses = toArray(data, isCustomerAddress);
    
    const orderedAddresses = [
        addresses.find(a => a.addressType === "Billing"), 
        addresses.find(a => a.addressType === "Delivery"),
        addresses.find(a => a.addressType === "Secondary")
    ].filter(Boolean);
    
    const addressesExist = orderedAddresses.length > 0;
    
    return(
        <>
        { !addressesExist && <h3 className="fs-5">No Address Found</h3>}
        {addressesExist && ( 
            <div className="container-fluid d-flex justify-content-between align-items-center">
            {
                orderedAddresses.map((address, idx) => 
                (
                    <div key={idx}>
                        <h3 className="fs-5 my-3">{address?.addressType}:</h3>
                        <div className="mb-2">
                            <label className="form-label" htmlFor="address-line-1">Line 1</label>
                            <input id="address-line-1" className="form-control" value={address?.line1} readOnly/>
                        </div>
                        <div className="mb-2">
                            <label className="form-label" htmlFor="address-line-2">Line 2</label>
                            <input id="address-line-2" className="form-control" value={address?.line2} readOnly/>
                        </div>
                        <div className="mb-2">
                            <label className="form-label" htmlFor="postcode">Postcode</label>
                            <input id="postcode" className="form-control" value={address?.postcode} readOnly />
                        </div>
                    </div>                            
                )
            )}
            </div>
    
    )}
    </>
)}