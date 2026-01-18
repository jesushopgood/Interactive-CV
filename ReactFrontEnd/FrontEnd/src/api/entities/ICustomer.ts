type AddressType = "Billing" | "Delivery" | "Secondary";
type CustomerContactType = "Email" | "Mobile" | "Landline"; 


interface ICustomerAddress
{
    id: number;
    line1: string;
    line2: string;
    postcode:string;    
    addressType: AddressType
}

interface ICustomerNote
{
    id: number;
    customerId:string;
    message:string;
}

interface ICustomerContact
{
    id: number;
    customerId:string;
    customerContactType:CustomerContactType
    value:string;
}

export interface ICustomer
{
    customerId: string;
    customerTitle: string
    customerFirstName: string;
    customerSurname: string;
    customerEmailAddress:string;
    loyaltyPoints:string;
    addresses: ICustomerAddress[];
    customerContacts: ICustomerContact[];
    customerNotes: ICustomerNote[];
} 