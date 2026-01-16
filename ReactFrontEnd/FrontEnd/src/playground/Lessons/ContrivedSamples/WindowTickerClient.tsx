import { useState } from "react";
import useWindowTicker from "./useWindowTicker";
import useBlinkingMessage from "./BlinkingMessage";

export default function WindowTickerClient(){
    const messages = ["Hi World!", "Jesus is king", "Southampton FC"];

    const [message, setMessage] = useState("");
    
    useWindowTicker(messages, 2000);
    useBlinkingMessage(setMessage, "Jesus Is King!!", 2000);

    return (
        <div>
            <div>Check the browser title</div>
            <div className="container border border-primary mh-100">{message}</div>
            
        </div>
    )
}
