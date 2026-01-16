import { useState } from "react";
import usePrevious from "./usePrevious";

export default function PrevClient()
{
    const [value, setValue] = useState("");
    const prev = usePrevious(value);
    const prevMinusOne = usePrevious(prev ?? "");

    return (
        <div className="container">
            <p><input type="text" value={value} onChange={(e) => setValue(e.target.value)} placeholder="Enter a new Value" /></p>
            <p>Current: {value}</p>
            <p>Previous: {prev}</p>
            <p>Prev Minus One: {prevMinusOne}</p>
        </div>
    )
}