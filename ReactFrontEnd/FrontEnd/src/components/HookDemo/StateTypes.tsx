interface Names
{
    firstname: string;
    middlename: string;
    lastname: string;
}

interface EmailDetails
{
    names: Names;
    email: string;
    password: string;
    checkOn: boolean;
}

interface ActionType
{
    type: string;
    value: string | boolean | EmailDetails;
}

const initialState: EmailDetails = { names: {firstname: "", middlename: "", lastname: ""},  email: "", password: "", checkOn: false} 
    

export type {Names, EmailDetails, ActionType}
export { initialState }