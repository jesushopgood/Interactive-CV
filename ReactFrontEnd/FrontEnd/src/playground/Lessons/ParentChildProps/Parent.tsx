import { useState } from "react";
import { Child } from "./Child";

type parentProps = {
    parentName: string;
    parentAge: number;
}

export function Parent({ parentName, parentAge }: parentProps){
    const [stuff, setStuff] = useState<string>("");  
 
    const displayStuff = (message: string) => { setStuff(`It Worked with message '${message}'`) }

    return (
        <>
            <h4>Parent</h4>
            <p>{stuff}</p>
            <Child name={parentName} age={parentAge} parentDisplay={displayStuff} />
        </>
    );
}