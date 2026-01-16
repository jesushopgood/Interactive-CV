import { useCallback, useMemo, useState } from "react";
import ChildTextTransform from "./ChildTextTransform";
import ChildTextColour from "./ChildTextColour";
import ChildTextSize from "./ChildTextSize";

export default function Parent() {
    const textTransforms = useMemo(() => ["text-lowercase", "text-uppercase", "text-capitalize"], []);
    const textColours = useMemo(() => ['text-primary', 'text-secondary', 'text-success', 'text-danger'], []);
    const textSizes = useMemo(() => ['display-1', 'display-2', 'display-3', 'display-4'], []);

    const [transformListIndex, setTransformListIndex] = useState(0);
    const [textColourIndex, setTextColourIndex] = useState(0);
    const [textSizeIndex, setTestSizeIndex] = useState(0);

    const [stateOnOff, setStateOnOff] = useState('off');
    
    const changeTextClass = useCallback(() => {
        setTransformListIndex(prev => prev === textTransforms.length - 1 ? 0 : prev + 1);
    }, [textTransforms.length]);

    const changeColourClass = useCallback(() => {
        setTextColourIndex(prev => prev === textColours.length -1 ? 0 : prev + 1);
    }, [textColours.length])

    const changeTextSizeClass = useCallback(() => {
        setTestSizeIndex(prev => prev === textSizes.length - 1 ? 0 : prev + 1);
    }, [textSizes.length])

    const clickHandler = () => {
        setStateOnOff(stateOnOff === 'on' ? 'off' : 'on');
    }

    return (
        <div className="container">
            <div>
                <h3>Parent Comp - Memoization Example</h3>
            </div>  
            <h4 className={`${textColours[textColourIndex]} ${textTransforms[transformListIndex]} ${textSizes[textSizeIndex]}`}>This is the message</h4>
            <p>
                <ChildTextTransform changeTransform={changeTextClass} />
            </p>
            <p>
                <ChildTextColour changeColour={changeColourClass} />
            </p>
            <p>
                <ChildTextSize changeTextSize={changeTextSizeClass} />
            </p>
            <p>Parent Action</p>
            <p><button onClick={clickHandler}>{stateOnOff}</button></p>
        </div>
    );
}