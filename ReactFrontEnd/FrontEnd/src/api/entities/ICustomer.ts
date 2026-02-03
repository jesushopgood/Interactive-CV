type AddressType = "Billing" | "Delivery" | "Secondary";
type CustomerContactType = "Email" | "Mobile" | "Landline"; 

export interface ICustomerAddress
{
    id: number;
    line1: string;
    line2: string;
    postcode:string;    
    addressType: AddressType
}

export function isCustomerAddress(value: unknown): value is ICustomerAddress {
    if (typeof value !== "object" || value === null) return false;

    const obj = value as Record<string, unknown>;

    return (
        typeof obj.id === "number" &&
        typeof obj.line1 === "string" &&
        typeof obj.line2 === "string" &&
        typeof obj.postcode === "string" &&
        typeof obj.addressType === "string"
    );
}


export function toArray<T>(value: unknown, isTypeFn: (value: unknown) => value is T): T[] {
    if (Array.isArray(value) && value.every(isTypeFn)) {
        return value;
    }

    return [] as T[];
}
export interface ICustomerNote
{
    id: number;
    customerId:string;
    message:string;
    messageDate: Date;
}

export function isCustomerNote(value: unknown): value is ICustomerNote {
    if (typeof value !== "object" || value === null)  return false;
    
    const obj = value as Record<string, unknown>;
    
    return (
        typeof obj.id === "number" &&
        typeof obj.customerId === "string" &&
        typeof obj.message === "string"
    );
}

export interface ICustomerContact
{
    id: number;
    customerId:string;
    customerContactType:CustomerContactType
    value:string;
}

export function isCustomerContact(value: unknown): value is ICustomerContact {
    if (typeof value !== "object" || value === null) return false;

    const obj = value as Record<string, unknown>;

    return (
        typeof obj.id === "number" &&
        typeof obj.customerId === "string" &&
        typeof obj.value === "string"
    );
}

export interface ICustomerName
{
    title: string
    firstName: string;
    surname: string;
}

export interface ICustomer
{
    customerId: string;
    customerName: ICustomerName;
    customerEmailAddress:string;
    loyaltyPoints:string;
    addresses: ICustomerAddress[];
    customerContacts: ICustomerContact[];
    customerNotes: ICustomerNote[];
} 

export const emptyCustomer: ICustomer = {
  customerId: "",
  customerName: { title: '', firstName: '', surname: ''},
  customerEmailAddress: "",
  loyaltyPoints: "",
  addresses: [],
  customerContacts: [],
  customerNotes: []
}