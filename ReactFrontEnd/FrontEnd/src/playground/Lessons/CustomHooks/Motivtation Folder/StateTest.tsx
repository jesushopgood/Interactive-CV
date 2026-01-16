import { useState } from "react";

export default function StateTest(){
    const[counterValue, setCounterValue] = useState(0);

    const increment = () => {
        setCounterValue(prev => prev + 1);
    }

    return(
        <div>
            <h3>{counterValue}</h3>
            <button className="btn btn-lg btn-primary" onClick={increment}>Increment</button>
        </div>
    ) 
}