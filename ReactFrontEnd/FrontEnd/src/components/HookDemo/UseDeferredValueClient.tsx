import { useState, useDeferredValue, useMemo } from "react";
import { withHighlight } from "../Highlight/withHighlight";

export default function UseDeferredValueDemo() {
    const [totalButtons, setTotalButtons] = useState(0);
    const [useDeferred, setUseDeferred] = useState(false);

    const deferredTotal = useDeferredValue(totalButtons);
    
    const updateTotalButtons = (val: string) => {
        setTotalButtons(parseInt(val, 10));
    }

    const renderLength = useDeferred ? deferredTotal : totalButtons;

    const badges = useMemo(() => {
        return Array.from({ length: renderLength }, (_, i) => (
            <span key={i} className="badge text-bg-secondary">Badge {i}</span>
    ))}, [renderLength]);

    return (
    <div className="container-fluid">
        <span className="badge text-bg-danger mb-3">Use Defer is {useDeferred ? "ON" : "OFF"}</span>
        <p>{'{'} Actual Value : {totalButtons} Deferred Value : {useDeferred ? deferredTotal : "N/A"} {'}'}</p>

        <div className="my-3">
            <label htmlFor="button-range" className="form-label fs-5">Total Buttons</label>
            <input id="button-range" type="range" className="form-range" min="0" max="50000" 
                    step="100" value={useDeferred ? deferredTotal : totalButtons} onChange={(e) => updateTotalButtons(e.target.value)} />
        </div>
        <div className="mb-3">
            <button className="btn btn-primary" onClick={() => 
                setUseDeferred(prev => !prev)}>Turn {useDeferred ? "Off" : "On"}</button>
        </div>
        <div className="d-flex justify-content-start gap-1 align-items-center flex-wrap vertical-scroll-700">
            {badges}
        </div>
    </div>
  );
}

export const UseCallbackClient = withHighlight(UseDeferredValueDemo,
"useDeferredValue()",

`useDeferredValue takes a fast‑changing value and intentionally lets it lag, 
giving React time to compute expensive results without blocking the user. 
It’s perfect when the input should feel immediate, but the derived work — filtering, 
rendering lists, crunching data — can safely trail behind.`,

`//Deferred value declared on live value
const deferredTotal = useDeferredValue(totalButtons);
...
//Switch allows using the real or deferred value
const renderLength = useDeferred ? deferredTotal : totalButtons;

//Use the renderLength value to recalculate on the expensive operation 
const badges = useMemo(() => {
    return Array.from({ length: renderLength }, (_, i) => (
        <span key={i} className="badge text-bg-secondary">Badge {i}</span>
))}, [renderLength]);
`);