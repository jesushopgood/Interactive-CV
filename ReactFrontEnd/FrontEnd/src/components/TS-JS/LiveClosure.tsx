/* eslint-disable react-hooks/refs */
import { useRef, useState } from "react";

interface MakeLoggerProps
{
    value: number;
}

type MakeLogger = (obj : MakeLoggerProps) => () => void;

export default function LiveClosure(){
    const [value, setValue] = useState(0);
    const [closureValue, setClosureValue] = useState(0);
    
    const makeLoggerRef = useRef<MakeLogger>((obj : MakeLoggerProps) => {
        return () => setClosureValue(obj.value);  
    });

    const data = { value: 1 };
    const log = makeLoggerRef.current(data);

    const updateValue = (val: number) => {
        setValue(val);
        data.value = val;
        log();
    }

    return (
        <div className="container-fluid">
            <div className="mb-3">
                <label htmlFor="new-value" className="form-label">New Value</label>
                <input id="new-value" type="number" className="form-control w-25" value={value} 
                        onChange={(e) => updateValue(parseInt(e.target.value))}/>
            </div>
            <div className="mb-3">
                <label htmlFor="closure-value" className="form-label">Closure Value</label>
                <input id="closure-value" type="number" className="form-control w-25" value={value} readOnly />
            </div>
        </div>
    )    
}