import { useRef, useState } from "react";

export default function RefComparison(){
    console.log("Re-render ALERT!!!");

    const [value, setValue] = useState(0);
    const [refMessage, setRefMessage] = useState("");
    const refValue = useRef(0);

    const increment = () => {
        setValue(prev => prev + 1);
    };

    const updateRef = () => {
        refValue.current = refValue.current + 1;
        if (refValue.current % 5 === 0){
            setRefMessage(`The value of ref is now ${refValue.current}`);
        }
    };

    return(
        <div>
            <h3>useState: {value}</h3>
            <h3>useRef: {refMessage}</h3>

            <div>
                <button className="btn btn-lg btn-primary" onClick={increment}>Increment</button>
            </div>
            <div>
                <button className="btn btn-lg btn-secondary" onClick={updateRef}>Update Ref</button>
            </div>
        </div>
    )
}