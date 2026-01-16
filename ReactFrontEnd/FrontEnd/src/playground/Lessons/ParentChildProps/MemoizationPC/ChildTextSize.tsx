import React from "react";

type ChildProps = { 
    changeTextSize: () => void;
 }

const ChildTextSize = React.memo(function ChildTextSize({changeTextSize} : ChildProps){
    console.log("ChildTextSize render...");
    return(
        <button onClick={changeTextSize}>Change Size</button>
    )
});

export default ChildTextSize;