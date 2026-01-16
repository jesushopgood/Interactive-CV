import { useState } from "react";
import useGenerateRandom from "./useGenerateRandom";
import React from "react";

export default function RandomNumberClient(){
    const [totalNums, setTotalNums] = useState(1);
    const [min, setMin] = useState(1);
    const [max, setMax] = useState(2);
    const [parentVal, setParentVal] = useState(0);

    const randomNumbers = useGenerateRandom({totalNumbers: totalNums, minNumber: min, maxNumber: max} );
    
    const updateParentVal = () => {
        setParentVal(prev => prev + 1);
    }

    const parseHint = (num: string) => {
        return !isNaN(parseInt(num)) ? parseInt(num) : 0;
    } 

    return (
        <div>
            <div>
                <p>Total: <input type="text" onChange={(e) => setTotalNums(parseHint(e.target.value))}value={totalNums} /></p>
                <p>Min: <input type="text" value={min} onChange={(e) => setMin(parseHint(e.target.value))} /></p>
                <p>Max: <input type="text" value={max} onChange={(e) => setMax(parseHint(e.target.value))} /></p>
                <p><button className="btn btn-primary" onClick={updateParentVal}>Update Parent</button></p>
                <p>{parentVal}</p>
            </div>
            <ul>
                { randomNumbers.slice(0, 20).sort((a,b) => b - a).map((x, key) => <li key={key}>{x}</li>) }
            </ul>
    
        </div>
    )
}