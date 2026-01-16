import { useState } from "react";
import { withHighlight } from "../../Highlight/withHighlight";

export default function UseStateDemo(){

    const [firstname, setFirstname] = useState("");
    const [middlename, setMiddlename] = useState("");
    const [lastname, setLastname] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [isCheckOn, setIsCheckOn] = useState(false);

    const onSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        console.log(e);
        e.preventDefault();
    }
    
    return(
        <form className="p-3" onSubmit={onSubmit}>            
            <div className="mb-3">
                <label htmlFor="firstname" className="form-label">First Name</label>
                <input type="text" 
                        className="form-control" 
                        id="firstname"
                        value={firstname} 
                        onChange={(e) => setFirstname(e.target.value)} />

            </div>
            
            <div className="mb-3">
                <label htmlFor="middlename" className="form-label">Middle Name</label>
                <input type="text" 
                        className="form-control" 
                        id="middlename" 
                        value={middlename}
                        onChange={(e) => setMiddlename(e.target.value)} />
            </div>
            
            <div className="mb-3">
                <label htmlFor="lastname" className="form-label">Last Name</label>
                <input type="text" 
                        className="form-control" 
                        id="lastname"
                        value={lastname} 
                        onChange={(e) => setLastname(e.target.value)} />
            </div>
            
            <div className="mb-3">
                <label htmlFor="exampleInputEmail1" className="form-label">Email address</label>
                <input type="email" 
                        className="form-control" 
                        id="exampleInputEmail1" 
                        value={email}
                        aria-describedby="emailHelp" 
                        onChange={(e) => setEmail(e.target.value)} />
                <div id="emailHelp" className="form-text">We'll never share your email with anyone else.</div>
            </div>
            
            <div className="mb-3">
                <label htmlFor="exampleInputPassword1" className="form-label">Password</label>
                <input type="password" 
                        className="form-control" 
                        id="exampleInputPassword1"
                        value={password} 
                        onChange={(e) => setPassword(e.target.value)} />
            </div>
            
            <div className="mb-3 form-check">
                <input type="checkbox" 
                        className="form-check-input" 
                        id="exampleCheck1"
                        checked={isCheckOn} 
                        onChange={(e) => setIsCheckOn(e.target.checked)} />
                <label className="form-check-label" htmlFor="exampleCheck1">Check me out</label>
            </div>
            
            <button type="submit" className="btn btn-primary">Submit</button>
        </form>
    )
}

export const UseStateClient = withHighlight(UseStateDemo,
  "useState()",
  `useState is a React hook that lets a functional component store and update internal state by returning 
  a state value and a setter function; when the setter is called with a new value, 
  React schedules a re‑render so the UI reflects the updated state, 
  making it the fundamental mechanism for managing dynamic, interactive data within components.`,
   
  `
//Define a state variable and setter function
const [firstname, setFirstname] = useState("");

//Consume the variable to display the value and call setFirstName on each keypress
<div className="mb-3">
    <label htmlFor="firstname" className="form-label">First Name</label>
    <input type="text" 
            className="form-control" 
            id="firstname"
            value={firstname} 
            onChange={(e) => setFirstname(e.target.value)} />

</div>
  `
);

