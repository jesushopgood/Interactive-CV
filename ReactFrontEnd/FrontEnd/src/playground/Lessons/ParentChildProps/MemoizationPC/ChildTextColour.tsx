import React from "react";

type ChildProps = {
    changeColour: () => void;
}

const ChildTextColour = React.memo(function ChildTextColour({changeColour}: ChildProps){
    console.log("change colour...")
    return (
        <>
            <button onClick={changeColour}>Change Colour</button>
        </>
    )
});

export default ChildTextColour;