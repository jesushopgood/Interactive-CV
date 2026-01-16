import { useEffect, useRef } from "react";

export default function useSetTimeout(callback: () => void, elapse: number){

    const savedCallback = useRef<() => void>(null);

    useEffect(() => {
        savedCallback.current = callback;
    }, [callback]);

    useEffect(() => {
        const id = setTimeout(() => {
        if (savedCallback.current)
            savedCallback.current()
    }, elapse);

    return () => clearTimeout(id);
    
    }, [elapse]);
}