/* eslint-disable react-hooks/refs */
import { useRef, useState } from "react";

interface ClosureType
{
    getX: () => number;
    getY: () => number;
    setX: (val: number) => void;
    setY: (val: number) => void;
}

export default function SimpleClosure() {
  const [, forceRender] = useState(false);

  // Create the closure ONCE
  const closureRef = useRef<ClosureType | null>(null);

  if (closureRef.current === null) {
    closureRef.current = (() => {
      let x = 0;
      let y = 1;

      return {
        getX: () => x,
        getY: () => y,
        setX: (val: number) => {
          x = val;
          forceRender(prev => !prev);
        },
        setY: (val: number) => {
          y = val;
          forceRender(prev => !prev);
        }
      };
    })();
  }

  const closure = closureRef.current;

  return (
    <div className="container-fluid">
      <div className="mb-3">
        <label htmlFor="x-value" className="form-label">X Value</label>
        <input
          id="x-value"
          className="form-control w-25"
          type="number"
          value={closure.getX()}
          onChange={(e) => closure.setX(parseInt(e.target.value))}
        />
      </div>

      <div className="mb-3">
        <label htmlFor="y-value" className="form-label">Y Value</label>
        <input
          type="number"
          className="form-control w-25"
          value={closure.getY()}
          onChange={(e) => closure.setY(parseInt(e.target.value))}
        />
      </div>
    </div>
  );
}