import { useState } from "react";
import Child from "./Child";
import useTypewriter from "../Common/useTypewriter";

export default function Parent(){

    const globalId = "Id:12345";
    const [ancestorMessage, setAncestorMessage] = useState('');
    
    const handleChildDisplay = (msg: string) => {
        setAncestorMessage(msg);
    }

    const message = useTypewriter({ text: ancestorMessage ? `${ancestorMessage} displayed in Parent() component ` : "", speed: 40});
    
    return (
        <div className="card-shadow border border-dark">
            <div className="card-header">
                <h2 className="fs-5 text-uppercase text-primary">Parent Component : {globalId}</h2>
            </div>
            <div className="card-body p-0">
                <Child id={globalId} childDisplay={handleChildDisplay} />
                { ancestorMessage && <h5 className="m-3 text-success">{message}</h5> }
            </div>
        </div>
    )

}