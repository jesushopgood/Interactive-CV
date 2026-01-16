import { useEffect, useRef, useState } from "react";

interface TimeoutOrIntervalProps
{
    funcType: typeof setTimeout | typeof setInterval;
    clearFuncType: typeof clearInterval | typeof clearTimeout;
    callback: () => void;
    elapse: number;
}

function useTimeoutOrInterval({funcType, clearFuncType, callback, elapse} : TimeoutOrIntervalProps){
    const callBackRef = useRef<() => void | null>(null);

    useEffect(() => {
        callBackRef.current = callback;
    }, [callback])

    useEffect(() => {
        const id = funcType(() => {
            if (callBackRef.current) callBackRef.current()
        }, elapse)

        return () => clearFuncType(id);

    }, [funcType, elapse])

}

export default function TimeoutIntervalClient(){

    const [timeoutResult, setTimeoutResult] = useState<number | null>(null);
    const [intervalResult, setIntervalResult] = useState<number | null>(null);
    const timeoutElapse = 3000;
    const intervalElapse = 2000;

    useTimeoutOrInterval({
        funcType: setTimeout,
        clearFuncType: clearTimeout,
        callback: () => setTimeoutResult(Math.ceil(Math.random() * 1000)),
        elapse: timeoutElapse
    });
    
    useTimeoutOrInterval({
        funcType: setInterval,
        clearFuncType: clearInterval,
        callback: () => setIntervalResult(Math.ceil(Math.random() * 1000)),
        elapse: intervalElapse
    });

    return (
        <div className="container-fluid">
            <p className="fs-5 fw-bold">Timeout Value : {timeoutResult} (after {timeoutElapse / 1000}s)</p>
            <p className="fs-5 fw-bold">Interval Result : {intervalResult} (every {intervalElapse / 1000}s)</p>
        </div>
    )
}