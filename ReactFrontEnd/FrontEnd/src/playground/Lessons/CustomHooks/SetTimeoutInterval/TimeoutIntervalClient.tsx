import { useState } from "react";
import useSetTimeout from "./useSetTimeOut";
import useSetInterval from "./useSetInterval";
import useFuncSelector from "./useFuncSelector";

export default function TimeoutIntervalClient() {
  
    const [firstMessage, setFirstMessage] = useState("Waiting for 1st timer...");
    const [secondMessage, setSecondMessage] = useState("Waiting for 2nd timer...");
    const [thirdMessage, setThirdMessage] = useState("Waiting for 3rd timer");

    const [currentDate, setCurrentDate] = useState<Date>(new Date());
    const [firstFunc, setFirstFunc] = useState("");
    const [secondFunc, setSecondFunc] = useState("");

    useSetTimeout(() => {
        setFirstMessage("Completed 1st message after 3000ms")
    }, 3000);  

    useSetTimeout(() => {
        setSecondMessage("Completed 2nd message after 6000ms")
    }, 6000)

    useSetTimeout(() => {
        setThirdMessage("Completed 2nd message after 9000ms")
    }, 9000)

    useSetInterval(() => {
        setCurrentDate(new Date())
    }, 3000);

    useFuncSelector(setFirstFunc,setSecondFunc,1000);

    return (
        <div>
            <h2>Timeouts</h2>
            <div className="container p-2" >
                <p>1st:{firstMessage}</p>
                <p>2nd:{secondMessage}</p>
                <p>3rd:{thirdMessage}</p>
            </div>

            <h2>Intervals</h2>
            <div className="container p-2">
                <h2>Interval: {currentDate.toISOString()}</h2>
            </div>

            <h2>Func Selector</h2>
            <div className="container p-2">
            <p>Func1 : {firstFunc}</p>
            <p>Func2 : {secondFunc}</p>
            </div>
        </div>
    );
}

