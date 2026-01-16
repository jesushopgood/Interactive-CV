import { LoggedInUserProvider } from "./LoggedInUserProvider";
import { ParentComponent } from "./ParentComponent";
import GrandchildComponent from "./GrandchildComponent";
import ChildComponent from "./ChildComponent";
import { useEffect, useState, type JSX } from "react";
import useTypewriter from "../../Common/useTypewriter";
import { useAnnotation } from "../../../annotations-engine/hooks/useAnnotation";
import { layoutEvents } from "../../../event-bus/layoutEvents";
import WrapperActionsBase from "../../../component-tree/WrapperActionsBase";

function ContextWrapper()
{
    const [,setTypewriterMessageDisplayed] = useState(false);

    const typewriterParams = 
    { 
        text: `Demonstrates how we can utilise useContext() to provide a property bag for any child element.
                    Whatever is wrapped in the Provider block will have access to the context. `, 
        speed: 10,
    }

    const message = useTypewriter(typewriterParams);
    const { targetElementRef: ref1 } = useAnnotation();
    const { targetElementRef: ref2 } = useAnnotation();

    useEffect(() => {
        layoutEvents.on("recalc:complete", () => { setTypewriterMessageDisplayed(true) } );
    },[]);

    return (
        <div className="card-shadow p-2" id="context-wrapper">
            <div className="card-header mb-sm-4" > 
                <h3 className="mb-2 fs-5 p-2 text-uppercase bg-primary text-white" ref={ref1}>Context Wrapper</h3>
                <div className="mb-2 p-2 fs-md-5 bg-primary text-white" ref={ref2}>
                    {message}
                </div>
            </div>

            {/* <AnnotationDot top={tc1.top} left={tc1.left} color="white" size={12} visible={true} />
            {
                typewriterMessageDisplayed && 
                <AnnotationDot top={tc2.top} left={tc2.left} color="white" size={12} visible={true} />
            } */}
            
            <div className="card-body rounded p-0 mt-2" >
                {new ContextWrapperActions().getHeirarchy()}
            </div>  
        </div>
    );
}


class ContextWrapperActions extends WrapperActionsBase
{
    getHeirarchy(): JSX.Element {
        return (
            <LoggedInUserProvider>
                <ParentComponent>
                    <ChildComponent>
                        <GrandchildComponent />
                    </ChildComponent>
                </ParentComponent>
            </LoggedInUserProvider>
        );
    }

    getHeirarchyAsString(): JSX.Element {
        return (
            // <ContextWrapper>
                <LoggedInUserProvider>
                    <ParentComponent>
                        <ChildComponent>
                            <GrandchildComponent />
                        </ChildComponent>
                    </ParentComponent>
                </LoggedInUserProvider>
            // </ContextWrapper>
        );
    }    
}

export { ContextWrapper, ContextWrapperActions }