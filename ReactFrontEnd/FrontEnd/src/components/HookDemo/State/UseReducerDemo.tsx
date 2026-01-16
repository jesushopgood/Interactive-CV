import { useEffect, useReducer, useState } from "react"
import { type ActionType, type EmailDetails } from "../StateTypes"
import { withHighlight } from "../../Highlight/withHighlight";

//Having a correct shape default value is useful for when we 
//dont want react to switch from uncontrolled to controlled
const emptyValue =
{
    names: { firstname: "", middlename: "", lastname: "" },  
    email: "", 
    password: "", 
    checkOn: false
}

const fakeLoadedValue = 
{
    names: {firstname: "Jim", middlename: "Jon", lastname: "Jones"},  
    email: "jj@poo.com", 
    password: "ddslkjfldkfj", 
    checkOn: false
}

export default function UseReducerDemo(){

    const [loading, setLoading] = useState(false);

    //state contains the existing value
    //action.value the new value and action.type is the key
    const reducer = (state: EmailDetails, action: ActionType) => {

        switch(action.type){
            case "setFirstName":
                return {
                    ...state,
                    names:{
                        ...state.names,
                        firstname: action.value as string
                    }
                }
            case "setMiddleName":
                return {
                    ...state,
                    names: {
                        ...state.names,
                        middlename: action.value as string
                    }
                }
            case "setLastName":
                return {
                    ...state,
                    names : {
                        ...state.names,
                        lastname: action.value as string
                    }
                }
            case "setEmail":
                return {
                    ...state,
                    email: action.value
                }
            case "setPassword":
                return {
                    ...state,
                    password: action.value
                }
            case "setCheckOn":
                return {
                    ...state,
                    checkOn: action.value
                }
            case "defaultLoaded":
                return {
                    ...state,
                    ...action.value as EmailDetails
                }
            default:
                return state;
        }
    }

    //For denontration purposes we pretend were getting an initial state from the 3rd parameter.
    const [state, dispatch] = useReducer(reducer, null, initialise);

    //The full load of the real value is done in the useEffect, so we just return the default value
    function initialise() {
        return emptyValue;
    }

    useEffect(() => {
        setLoading(true);
        const loadFromDisk = () => {
            setTimeout(() => {
                dispatch({ type: "defaultLoaded", value: fakeLoadedValue });
                setLoading(false);
            },3500)
        }
        loadFromDisk();
    }, []);
    
    const onSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        console.log(e);
        e.preventDefault();
    }
    
    return(
        <div className="form-wrapper">
            {
            loading && <div className="d-flex justify-content-center align-items-center spinner">
                <div className="spinner-border text-primary" role="status">
                    <span className="sr-only"></span>
                </div>
            
            </div>
            }
            <form className="p-3" onSubmit={onSubmit}>
                <fieldset disabled={loading}>
                    <div className="mb-3">
                    <label htmlFor="firstname" className="form-label">First Name</label>
                    <input type="text" 
                            className="form-control" 
                            id="firstname"
                            value={state.names.firstname} 
                            onChange={(e) => dispatch({type: "setFirstName", value: e.target.value })} />

                    </div>
                    <div className="mb-3">
                        <label htmlFor="middlename" className="form-label">Middle Name</label>
                        <input type="text" 
                                className="form-control" 
                                id="middlename" 
                                value={state.names.middlename}
                                onChange={(e) => dispatch({type: "setMiddleName", value: e.target.value })} />

                    </div>
                    <div className="mb-3">
                        <label htmlFor="lastname" className="form-label">Last Name</label>
                        <input type="text" 
                                className="form-control" 
                                id="lastname"
                                value={state.names.lastname} 
                                onChange={(e) => dispatch({type: "setLastName", value: e.target.value })} />

                    </div>
                    <div className="mb-3">
                        <label htmlFor="exampleInputEmail1" className="form-label">Email address</label>
                        <input type="email" 
                                className="form-control" 
                                id="exampleInputEmail1" 
                                value={state.email}
                                aria-describedby="emailHelp" 
                                onChange={(e) => dispatch({type: "setEmail", value: e.target.value })} />

                        <div id="emailHelp" className="form-text">We'll never share your email with anyone else.</div>
                    </div>
                    <div className="mb-3">
                        <label htmlFor="exampleInputPassword1" className="form-label">Password</label>
                        <input type="password" 
                                className="form-control" 
                                id="exampleInputPassword1"
                                value={state.password} 
                                onChange={(e) => dispatch({type: "setPassword", value: e.target.value })}/>
                    </div>
                
                    <div className="mb-3 form-check">
                        <input type="checkbox" 
                                className="form-check-input" 
                                id="exampleCheck1" 
                                onChange={(e) => dispatch({type: "setCheckOn", value: e.target.value })}/>
                        <label className="form-check-label" htmlFor="exampleCheck1">Check me out</label>
                    </div>
                
                    <button type="submit" className="btn btn-primary">Submit</button>
                </fieldset>
            </form>
        </div>
    )
}

export const UseReducerClient = withHighlight(UseReducerDemo,
  "useReducer()",
  `useReducer is a React hook designed for managing state transitions that have clear, 
  event‑driven logic. Instead of calling multiple setState functions, you dispatch actions that describe what happened, 
  and a reducer function decides how the state should change. 
  It’s ideal when updates depend on previous state, when several pieces of state change together, 
  or when you want predictable, testable state transitions. 
  In short, useReducer gives you a clean, centralized way to manage complex or coordinated state updates.
`,
    
    `
    //Reduder function contains switch statements for each state item
    switch(action.type){
        case "setFirstName":
            return {
                ...state,
                names:{
                    ...state.names,
                    firstname: action.value as string
                }
            }
    ...
    //State represents the entire object, 1st param is reducer fn, second initial state and 3rd a function that returns
    //initial state, dispatch is the set method            
    const [state, dispatch] = useReducer(reducer, null, initialise);
    ...
    //Example usage
    <input  ...
            value={state.names.firstname} 
            onChange={(e) => dispatch({type: "setFirstName", value: e.target.value })} />      
    `
);