/* eslint-disable react-hooks/set-state-in-render */
import { useEffect, useState } from "react";

export default function StaleUseEffect() {
  const [staleCount, setStaleCount] = useState(0);
  const [freshCount, setFreshCount] = useState(0);
  const [functionalUpdateCount, setFunctionalUpdateCount] = useState(0);

  //1....       This effect has no dependemcy array so will never be called a second time
  //            the log() gets stuck with the old value 
  useEffect(() => {
    const id = setInterval(() => {
      console.log(`staleCount : ${staleCount}`); 
    }, 1000);

    return () => clearInterval(id);
  }, []);

  //2.....  This effect will get re run from new due to the correct dependency array 
  useEffect(() => {
    const id = setInterval(() => {
      console.log(`freshCount ${freshCount}`); 
    }, 1000);

    return () => clearInterval(id);
  }, [freshCount]);

  //3....  Functional updates prevent the problem of the stale useEffect withut a dependency array 
  useEffect(() => {
    const id = setInterval(() => {
      setFunctionalUpdateCount(prev => prev + 1);    
    }, 2000);

    return () => clearInterval(id);
  }, [])

  return (
    <div className="container-fluid d-flex justify-content-start gap-2">
      <input className="w-25 form-control fs-2" value={staleCount} readOnly />
      <button className="btn btn-primary me-2" value={staleCount} 
            onClick={() => setStaleCount(prev => prev + 1)}>Increment Stale</button>
      <input className="w-25 form-control fs-2" value={freshCount} readOnly />
      <button className="btn btn-primary me-2" value={freshCount} 
            onClick={() => setFreshCount(prev => prev + 1)}>Increment Fresh</button>
      <label htmlFor="functional-update" className="form-label">Function Update Count</label>
      <input id="functional-update" className="w-25 form-control fs-2" value={functionalUpdateCount} readOnly/>   
    </div>
  )
}
