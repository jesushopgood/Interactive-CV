/* eslint-disable react-hooks/refs */
import { useEffect, useRef, useState } from "react";

function usePrevious<T>(value: T){

    const previousRef = useRef<T>(value);

    useEffect(() => {
        previousRef.current = value;
    }, [value])

    return previousRef.current ?? "EMPTY";
}

export default function UsePreviousClient(){
    const [passcode, setPasscode] = useState("");
    const prevPasscode = usePrevious(passcode);

    return (
        <div className="container-fluid">
            <form>
                <h2>Previous passcode: {prevPasscode}</h2>
                <label form="passcode" className="form-label">Passcode</label>
                <input className="form-control" value={passcode} onChange={(e) => setPasscode(e.target.value)} />
            </form>
        </div>
    )
}