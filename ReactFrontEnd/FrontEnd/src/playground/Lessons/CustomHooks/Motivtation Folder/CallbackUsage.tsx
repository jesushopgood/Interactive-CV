import { useCallback, useEffect, useState } from "react";

export default function CallbackUsage(){
    const [count, setCount] = useState(0);
    const [okToIncrement, setOkToIncrement] = useState(true);
    
    //This is now a stable function so it will be created 
    //only when OkToIncrementChanges
    const increment = useCallback(() => {
        if (okToIncrement) setCount(prev => prev + 1)
    },[okToIncrement]);

    useEffect(() => {
        const id = setInterval(() => {
            increment();    
        },1000);

        return () => clearInterval(id);
    },[increment])

    const handleClick = () => {
        setOkToIncrement(prev => !prev);
    }

    return (
        <>
            <h2>Count is {count} </h2>
            <h3>Increment is {okToIncrement ? 'ON' : 'OFF'}</h3>
            <button onClick={handleClick}>TURN {okToIncrement ? 'OFF' : 'ON'}</button>
        </>
    )
}