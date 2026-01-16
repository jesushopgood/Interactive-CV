import { useState, useTransition, useMemo } from "react";
import { withHighlight } from "../Highlight/withHighlight";

export default function UseTransitionDemo() {
  const [query, setQuery] = useState("");
  const [useTransitionBlock, setUseTransitionBlock] = useState(true);

  const [isPending, startTransition] = useTransition();
  const bigList = useMemo(() => {
    return Array.from({ length: 20000 }, (_, i) => `Item ${i}`);
  }, []);

  const handleChange = (e) => {
    const value = e.target.value;
    if (useTransitionBlock){
      startTransition(() => {
        setQuery(value);
      });
    }
    else{
      setQuery(value); 
    }
  };

  const filteredList = useMemo(() => {
    return bigList.filter((item) => item.includes(query));
  }, [query, bigList]);

  return (
    <div className="container-fluid">
      <h3>useTransition Demo</h3>
      
      <div className="mb-3">
        <label className="form-label">Type to filter 20,000 items</label>
        <input className="form-control" onChange={handleChange} />
      </div>

      {isPending && (
        <div className="alert alert-info">Updating list…</div>
      )}

      <div className="mb-3">
        <button className="btn btn-primary" onClick={() => 
                setUseTransitionBlock(prev => !prev)}>Turn {useTransitionBlock ? "Off" : "On"}</button>
      </div>

      <ul className="vertical-scroll-700">
        {filteredList.map((item) => (
          <li key={item}>{item}</li>
        ))}
      </ul>
    </div>
  );
}

export const UseTransitionClient = withHighlight(UseTransitionDemo,
"useTransition()",

`useTransition lets you split state updates into “urgent” and “non‑urgent,” 
so fast interactions like typing or clicking stay instant while heavier UI updates happen in the background. 
It’s React’s way of saying: keep the interface responsive first, then fill in the expensive stuff when 
there’s breathing room`,

`//startTransition sets the result of the state udpate in the background, 
//isPending tells you that its running 
const [isPending, startTransition] = useTransition()
...
//Call to setQuery will trigger the filter, 
// so startTransition will send the update to the background
const handleChange = (e) => {
    const value = e.target.value;
    if (useTransitionBlock){
      startTransition(() => {
        setQuery(value);
      });
    }
    else{
      setQuery(value); 
}`
);