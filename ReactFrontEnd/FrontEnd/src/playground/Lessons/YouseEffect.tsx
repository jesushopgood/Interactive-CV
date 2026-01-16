import { useState, useEffect } from "react";

function YouseEffect(){
    
    const [count, setCount] = useState<number>(0);

    useEffect(() => {
        setTimeout(() => {
            setCount(count => count + 1)
        },5000);
    },[])
    
    return (
        <h5>Count is {count}</h5>
    )
}

export default YouseEffect;