import { useEffect, useState } from "react";

export default function AsyncClosures(){
    const logLaterTime = 5000;
    
    const [counter, setCounter] = useState(0);
    const [logLaterMessage, setLogLaterMessage] = useState<string | null>(null);
    const [messageClass, setMessageClass] = useState<string>("");
    const [seconds, setSeconds] = useState(logLaterTime / 1000);
    const [startInterval, setStartInterval] = useState(false);

    const logLater = () => {
        setStartInterval(true);
        setSeconds(logLaterTime / 1000);
        setLogLaterMessage(`logLater() Activated initial counter value is ${counter}`);
        setMessageClass("text-primary");
        setTimeout(() => {
            setMessageClass("text-danger");
            setLogLaterMessage(`Logging counter after 5s counter is still ${counter}`); 
            setStartInterval(false) 
        }, logLaterTime)
    
    }

    useEffect(() => {
        if (!startInterval) return ;
        
        const id = setInterval(() => {
            setSeconds(prev => prev -1);
        },1000)

        return () => clearInterval(id);

    },[startInterval])

    const increment = () => {
        setCounter(counter + 1);
    }

    return (
        <div className="container-fluid">
            <p className={messageClass}><strong>{logLaterMessage}</strong></p>
            <p><strong>Time Remaining: {seconds}/{logLaterTime / 1000}</strong></p>
            <div className="mb-3">
                <label htmlFor="increment-value" className="form-label">Increment</label>
                <input id="increment-value"className="form-control w-25" value={counter} readOnly />
            </div>
            <div className="container-fluid d-flex justify-content-start p-0">
                <button className="btn btn-primary" onClick={logLater}>Log Later</button>
                <button className="btn btn-danger ms-2" onClick={increment}>Increment</button>
            </div>
        </div>
    )
}