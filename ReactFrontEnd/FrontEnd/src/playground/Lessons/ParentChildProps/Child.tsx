import { useState } from "react";

type ChildProps = { name: string, age: number, parentDisplay: (val: string) => void };

export function Child({name, age, parentDisplay} : ChildProps){
    const [message, setMessage] = useState<string>("");

    return (
        <>
            <p>{name} : { age }</p>
            <input type="text" value={message} onChange={e => setMessage(e.target.value)} />
            <button onClick={() => parentDisplay(message)}>Click Me</button>
        </>
    )
}