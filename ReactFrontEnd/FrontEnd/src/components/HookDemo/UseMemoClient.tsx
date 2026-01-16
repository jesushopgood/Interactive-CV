/* eslint-disable react-hooks/exhaustive-deps */
/* eslint-disable react-hooks/purity */
import { useEffect, useMemo, useState } from "react";
import { withHighlight } from "../Highlight/withHighlight";

function RandomHash({ length = 10000, interval = 10000 }) {
  const [tick, setTick] = useState(0);
  const [remaining, setRemaining] = useState(interval / 1000);

  useEffect(() => {
    const id = setInterval(() => {
      setTick(prev => prev + 1);
    },interval)

    return () => clearInterval(id);
  }, [interval]);

  useEffect(() => {
    const id = setInterval(() => {
      setRemaining(prev => prev === 0 ? interval / 1000 : prev - 1);    
    },1000);

    return () => clearInterval(id);
  }, [interval])

  const hash = useMemo(() => {
    const monsterArray = new Array(length).fill(Math.random() * 1000);
    return monsterArray.reduce((acc, n) => acc + (Math.sqrt(n)));
  }, [tick, length])

  return (
    <>
      <p> Login Key: {Math.round(hash)} Remaining: {remaining}s</p>
    </>
  )
}

function UseMemo(){
  return (
    <form>
      <div className="mb-3">
        <label className="form-label"><RandomHash /></label>
      </div>
      <div className="mb-3">
        <label htmlFor="email" className="form-label">Login Key</label>
        <input id="login-key" type="login-key" className="form-control"/>
      </div>
      <div className="mb-3">
        <label htmlFor="email" className="form-label">User name</label>
        <input id="email" type="email" className="form-control" />
      </div>
      <div className="mb-3">
        <label htmlFor ="password" className="form-label">Password</label>
        <input id="password" className="form-control" />
      </div>
      <div className="mb-3">
        <button className="btn btn-primary">LOG IN</button>
      </div>
    </form>
  )
} 

export const UseMemoClient = withHighlight(UseMemo,
  "useMemo()",
  `The 'useMemo()' hooks memoizes the expensive calculation below. It utilizes a dependency array,
   in this case only changing when tick (a value changing every n milliseconds) or array length change.`,
   
  `const hash = useMemo(() => {
    const monsterArray = new Array(length).fill(Math.random() * 1000);
    return monsterArray.reduce((acc, n) => acc + (Math.sqrt(n)));
  }, [tick, length])`
);