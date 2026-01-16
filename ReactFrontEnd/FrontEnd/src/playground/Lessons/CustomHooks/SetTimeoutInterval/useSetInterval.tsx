import { useEffect, useRef } from "react";

export default function useSetInterval(callback: () => void, elapse: number){

    const savedCallback = useRef<() => void>(null);

    useEffect(() => {
        savedCallback.current = callback;
    }, [callback])

    useEffect(() => {
        const id = setInterval(() => {
            if (savedCallback.current)
                savedCallback.current();
        }, elapse);

        return () => clearInterval(id);
    }, [elapse])
}