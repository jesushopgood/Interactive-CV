import React from "react";

type ChildProps = {
    changeTransform : () => void;
}

const ChildTextTransform =  React.memo(function ChildTextTransform({changeTransform} : ChildProps){
    console.log('Child Transform Render ...');
    return(
        <button onClick={changeTransform}>Change Appearance</button>
    )
});

export default ChildTextTransform;