import { useEffect, useRef, useState } from "react";
import { withHighlight } from "../Highlight/withHighlight";

export default function UseRefDemo(){
    const [raceRunning, setRaceRunning] = useState(false);
    const [runnerOneDistance, setRunnerOneDistance] = useState(0);
    const [runnerTwoDistance, setRunnerTwoDistance] = useState(0);
    const [runnerThreeDistance, setRunnerThreeDistance] = useState(0);
    const [sprintFinish, setSprintFinish] = useState(false);

    const counterRef = useRef<number>(-1);
    const runnerOneRef = useRef<HTMLInputElement | null>(null);
    const runnerTwoRef = useRef<HTMLInputElement | null>(null);
    const runnerThreeRef = useRef<HTMLInputElement | null>(null);

    //The set NextNumberX are async and may not have completed so we read the new values 
    //in the second useEffect which wont run until the values have changed (due to the dependency array)    
    useEffect(() => {
        if (!raceRunning) return;

        const addRandom = (val:number) => Math.trunc(val + Math.random() * (sprintFinish ? 6 : 3));

        counterRef.current = setInterval(() => {
            setRunnerOneDistance(prev => addRandom(prev));
            setRunnerTwoDistance(prev => addRandom(prev));    
            setRunnerThreeDistance(prev => addRandom(prev));
        },100);

        return () => clearInterval(counterRef.current);
    },[raceRunning, sprintFinish])

    useEffect(() => {
        const max = Math.max(runnerOneDistance, runnerTwoDistance, runnerThreeDistance);
        if (max === runnerOneDistance) runnerOneRef.current?.focus();
        if (max === runnerTwoDistance) runnerTwoRef.current?.focus();
        if (max === runnerThreeDistance) runnerThreeRef.current?.focus();
    },[runnerOneDistance, runnerTwoDistance, runnerThreeDistance])

    const startRace = (e: React.FormEvent<HTMLButtonElement>) => {
        setRaceRunning(true);
        e.preventDefault()
    }

    const stopRace = (e: React.FormEvent<HTMLButtonElement>) => {
        setRaceRunning(false);
        e.preventDefault()                
    }

    const restartRace = (e: React.FormEvent<HTMLButtonElement>) => {
        e.preventDefault();
        setRaceRunning(false);
        clearInterval(counterRef.current);
        setRunnerOneDistance(0);
        setRunnerTwoDistance(0);
        setRunnerThreeDistance(0);
    }
    
    const updateSprintFinish = (e: React.FormEvent<HTMLButtonElement>) => {
        e.preventDefault();
        setSprintFinish(prev => !prev)
    }

    const getWhoseWinning = (runnerDistance: number) => runnerDistance > 0 && 
                                runnerDistance === Math.max(runnerOneDistance, runnerTwoDistance, runnerThreeDistance);

    return (
            <form className="p-3">
                <div className="mb-3">
                    {   
                        !raceRunning && (runnerOneDistance > 0 || runnerTwoDistance > 0 || runnerThreeDistance > 0) && 
                        <p className="fs-2 text-primary">Race Completed</p> 
                    }
                    {
                        !raceRunning && (runnerOneDistance === 0 || runnerTwoDistance === 0 || runnerThreeDistance === 0) && 
                        <p className="fs-2 text-primary">Get Ready Runners!!!</p> 
                    }
                </div>
                <div className="mb-3">
                    <label htmlFor="runner-one" className="form-label">Runner One {runnerOneDistance}m {getWhoseWinning(runnerOneDistance) ? "is WINNING" : ""}</label>
                    <input type="text"
                            ref={runnerOneRef} 
                            className="form-control" 
                            id="runner-one"
                            onChange={e => setRunnerOneDistance(parseInt(e.target.value))}
                            value={"-".repeat(runnerOneDistance / 10)} /> 
                </div>

                <div className="mb-3">
                    <label htmlFor="runner-two" className="form-label">Runner Two {runnerTwoDistance}m {getWhoseWinning(runnerTwoDistance) ? "is WINNING" : ""}</label>
                    <input type="text"
                            ref={runnerTwoRef} 
                            className="form-control" 
                            id="runner-two"
                            onChange={e => setRunnerTwoDistance(parseInt(e.target.value))}
                            value={"-".repeat(runnerTwoDistance / 10)} />
                             
                </div>

                <div className="mb-3">
                    <label htmlFor="runner-three" className="form-label">Runner Three {runnerThreeDistance}m {getWhoseWinning(runnerThreeDistance) ? "is WINNING" : ""}</label>
                    <input type="text"
                            ref={runnerThreeRef} 
                            className="form-control" 
                            id="runner-three"
                            onChange={e => setRunnerThreeDistance(parseInt(e.target.value))}
                            value={"-".repeat(runnerThreeDistance / 10)} /> 
                </div>

                <div className="my-1">
                    <button className="btn btn-primary" onClick={(e) => startRace(e)}>Start</button>
                    <button className="btn btn-secondary mx-1" onClick={(e) => stopRace(e)}>End</button>
                    <button className="btn btn-danger" onClick={(e) => restartRace(e)}>Restart</button>
                    <button className="btn btn-primary mx-1" onClick={updateSprintFinish}>{sprintFinish ? "Run" : "Sprint"}</button>
                </div>
            </form>
    )
}

export const UseRefClient = withHighlight(UseRefDemo,
  "useRef()",
  `useRef is a React hook that gives you a way to hold onto a mutable value that persists across renders without 
  causing the component to re‑render when it changes. It’s perfect for storing things like DOM element references, 
  timers, previous values, or any piece of data that shouldn’t trigger a render cycle. 
  Think of it as a small, persistent “box” that React leaves untouched between renders, 
  letting you read or update its .current property whenever you need to.`,

  `//Declare a ref instance variable as below 
//This will be used to store a result from setInterval
const counterRef = useRef<number>(-1);

//counterRef presists across renders, 
//and changes to current don't force re-renders
useEffect(() => {
    ...
    counterRef.current = setInterval(() => {
        ...
    },100);

    return () => clearInterval(counterRef.current);
},[raceRunning, sprintFinish])`
);