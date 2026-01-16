import { useEffect, useRef } from "react";

export default function usePrevious(value: string) : string | undefined{
    const prev = useRef("");
    
    useEffect(() => {
        prev.current = value;
    }, [value]);
    
    return prev.current
}


