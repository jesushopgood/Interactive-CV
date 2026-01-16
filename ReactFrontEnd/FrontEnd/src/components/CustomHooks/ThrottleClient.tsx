
/* eslint-disable react-hooks/set-state-in-effect */
import { useEffect, useRef, useState } from "react";

function useThrottler(message: string, speed: number = 200){
    const [throttleMessage, setThrottleMessage] = useState("");
    const timeoutRef = useRef<number | null>(null);
    const lastValueRef = useRef("");

    useEffect(() => {
        const prev = lastValueRef.current;
        lastValueRef.current = message;

        if (prev.length > message.length || message.slice(message.length - 1, message.length) === " ")
        {
            if (timeoutRef.current){
                clearTimeout(timeoutRef.current);
            }

            setThrottleMessage(message);
            return;
        }    

        // If the user deleted characters → update immediately
        if (timeoutRef.current) clearTimeout(timeoutRef.current);

        timeoutRef.current = setTimeout(() => {
            setThrottleMessage(lastValueRef.current);
            timeoutRef.current = null;
        }, speed)

    }, [message, speed])
    
    return throttleMessage;
}

export default function ThrottleClient(){

    const [query, setQuery] = useState("");
    const nextValue = useThrottler(query, 500); 

    return(
        <form>
            <div className="mb-3">
                <label className="form-label" htmlFor="search-box">Search With Throttle</label>
                <input id="search-box" className="form-control" value={nextValue} onChange={e => setQuery(e.target.value)} />
            </div>
        </form>
    )
}
