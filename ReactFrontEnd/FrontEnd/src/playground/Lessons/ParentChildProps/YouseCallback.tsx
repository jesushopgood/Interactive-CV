import React, { useCallback } from "react";
import {  useState } from "react";

type ChildProps = { onIncrement :() => void; }

// Child component
const IncrementButton = React.memo(function IncrementButton({ onIncrement }: ChildProps) {
  console.log("Button rendered");
  return <button onClick={onIncrement}>Increment</button>;
});

export default function YouseCallback(){
    
  const [count, setCount] = useState(0);
  const [text, setText] = useState("");

  //useCallback ensures this function reference is stable
   const handleIncrement = useCallback(() => {
       setCount(prev => prev + 1);
   }, []);

  //unstable if the parent renders it will think its a new function 
  //and will cause a child render
    //const handleIncrement = () => setCount(prev => prev + 1);

  return (
    <div>
      <h2>Count: {count}</h2>
      <p><input type="text" value={text} onChange={e => setText(e.target.value)} /></p>
        { text.length && <p>{text}</p> }
      <p>
        <IncrementButton onIncrement={handleIncrement} />
      </p>
    </div>
  );
}   