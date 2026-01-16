import React from "react";
import { useState, useCallback } from "react";

interface ChildProps
{
    doClick: () => void;
    label: string;
    value: string
}

const BigButton = React.memo(function BigButton({doClick: handleClick, label, value}: ChildProps)
{
    console.log(`button ${label} rendered`)
    return(
        <>
            <button className="btn btn-lg btn-success" onClick={handleClick}>{label}</button>
            <p>{value}</p>
        </>
    )
});

export default function StillCallback(){
    const [oneValue, setOneValue] = useState("");
    const [twoValue, setTwoValue] = useState("");
    const [parentValue, setParentValue] = useState("");

    const clickHandlerOne = useCallback(() => {
        setOneValue(prev => prev + "X")
    }, []);

    const clickHandlerTwo = useCallback(() => {
        setTwoValue(prev => prev + "Y")
    }, []);

    const handleParentClick = useCallback(() => {
        setParentValue(prev => prev + "Z")
    },[]);

    return(
        <div>
            <BigButton doClick={clickHandlerOne} label="Button One" value={oneValue}/>

            <BigButton doClick={clickHandlerTwo} label="Button Two" value={twoValue}/>

            <button className="btn btn-lg btn-dark" onClick={handleParentClick}>Parent Set</button>
            <p>{parentValue}</p>
        </div>  
    )
}