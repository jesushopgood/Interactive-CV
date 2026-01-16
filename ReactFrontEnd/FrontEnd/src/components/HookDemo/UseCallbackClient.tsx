/* eslint-disable react-hooks/exhaustive-deps */
import { memo, useCallback, useEffect, useRef, useState } from "react";
import { withHighlight } from "../Highlight/withHighlight";

export default function UseCallbackDemo() {
    const [, setRender] = useState(false);
    const [displayMessage, setDisplayMessage] = useState("");
    
    const cancelChildRerenderFlag = useRef(false);
    const updateDisplayMessage = (msg: string) => setDisplayMessage(prev => prev.concat(msg, "\n"));
    const handleClick = (msg: string) => {
        cancelChildRerenderFlag.current = true; 
        updateDisplayMessage(msg);            
    }
    
    const updateRenderFlag = (flag: boolean) => cancelChildRerenderFlag.current = flag;
    const handleClickWithCallback = useCallback((msg: string) => updateDisplayMessage(msg),[]);
    const handleRender = () => {
        updateRenderFlag(false);
        setRender(prev => !prev);
    }
    const clear = () => {
        setDisplayMessage("");    
    }

    return (
        <div className="container-fluid h-75">
            <BasicComponent 
                handleClick={handleClick} updateRenderFlag={updateRenderFlag} cancelRenderFlag={cancelChildRerenderFlag.current} />
            <MemoComponent handleClick={handleClick} updateRenderFlag={updateRenderFlag} cancelRenderFlag={cancelChildRerenderFlag.current} />
            <MemoAndCallbackComponent handleClick={handleClickWithCallback} />

            <div className="mt-2 container-fluid p-0 h-50">
                <textarea
                    className="form-element w-100 p-2"
                    readOnly
                    value={displayMessage}
                    rows={6}
                />
            </div>

            <div className="container-fluid mt-2 p-2">
                <button className="btn btn-primary me-2 mt-2 w-25" onClick={() => handleRender()}>Force Render</button>
                <button className="btn btn-secondary me-2 mt-2 w-25" onClick={() => clear()}>Clear</button>
            </div>
        </div>
    );
}

interface ComponentProps {
    handleClick: (msg: string) => void;
    updateRenderFlag?: (flag: boolean) => void
    cancelRenderFlag?: boolean;
}

/* ---------------- BASIC COMPONENT ---------------- */

function BasicComponent({ handleClick, updateRenderFlag, cancelRenderFlag }: ComponentProps) {
    const clickMessage = "BASIC Component: Will always re-render. It has no callback or Memo!";
    
    useEffect(() => {        
        if (!cancelRenderFlag) handleClick(clickMessage);
        else if (updateRenderFlag) updateRenderFlag(true);
    });

    return (
        <div className="container-fluid d-flex justify-content-between align-items-center p-2 border border-black">
            <h2 className="fs-6">BASIC COMPONENT</h2>
            <div className="w-50 d-flex justify-content-end">
                <button className="btn btn-primary w-25" onClick={() => handleClick(clickMessage)}>
                    BASIC
                </button>
            </div>
        </div>
    );
}

/* ---------------- MEMO COMPONENT ---------------- */
const MemoComponent = memo(({ handleClick, updateRenderFlag, cancelRenderFlag }: ComponentProps) => {
    const clickMessage = "MEMO Component: Memo but handler is unstable → still re-renders";
    
    useEffect(() => {        
        if (!cancelRenderFlag) handleClick(clickMessage);
        else if (updateRenderFlag) updateRenderFlag(true);
    });

    return (
        <div className="container-fluid d-flex justify-content-between align-items-center p-2 mt-3 border border-black">
            <h2 className="fs-6">MEMO COMPONENT</h2>
            <div className="w-50 d-flex justify-content-end">
                <button className="btn btn-secondary w-25" onClick={() => handleClick(clickMessage)}>
                    MEMO
                </button>
            </div>
        </div>
    );
});

/* ---------------- MEMOandCALLBACK COMPONENT ---------------- */
const MemoAndCallbackComponent = memo(({ handleClick }: ComponentProps) => {
    const clickMessage = "MemoAndCallback Component: Memo + stable callback → does NOT re-render";

    useEffect(() => {
        handleClick(clickMessage);
    });

    return (
        <div className="container-fluid d-flex justify-content-between align-items-center p-2 mt-3 border border-black">
            <h2 className="fs-6">MEMO AND CALLBACK COMPONENT</h2>
            <div className="w-50 d-flex justify-content-end">
                <button className="btn btn-danger w-25" onClick={() => handleClick(clickMessage)}>
                    NO
                </button>
            </div>
        </div>
    );
});

export const UseCallbackClient = withHighlight(UseCallbackDemo,
"useCallback() & memo()",

`useCallback stabilizes the function reference; memo stabilizes the component.
Together, they prevent unnecessary re-renders by ensuring the child only re-renders when its real inputs change, 
not just because a new function was created.
`,
`const MemoAndCallbackComponent = memo(({ handleClick }: ComponentProps) => {
    const clickMessage = "MemoAndCallback Component: Memo + stable callback → does NOT re-render";

    useEffect(() => {
        handleClick(clickMessage);
    });
...
const handleClickWithCallback = useCallback((msg: string) => updateDisplayMessage(msg),[]);
`
);