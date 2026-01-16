import type { JSX } from "react";
import Parent from "./Parent";
import Child from "./Child"
import GrandChild from "./GrandChild";

import useTypewriter from "../Common/useTypewriter";
import WrapperActionsBase from "../../component-tree/WrapperActionsBase";

function PropsWrapper()
{
    
    const message = useTypewriter({ 
        text: `Shows how properties can be passed down and event bubbled up using useContext() `, 
        speed: 10,
    });
    
    return (
        <div className="card-shadow p-2">
            <div className="card-header mb-sm-4 bg-primary text-white">
                <h4 className="mb-2 text-uppercase">Properties Wrapper</h4>
                <p className="mb-1 fs-md-5">
                    {message}
                </p>
            </div>
            <div className="card-body rounded p-0 mt-2">
                {new PropsWrapperActions().getHeirarchy()}
            </div>  
        </div>
    );
}

class PropsWrapperActions extends WrapperActionsBase
{
    getHeirarchy(): JSX.Element {
        return (
            <Parent />
        );
    }
    
    getHeirarchyAsString() : JSX.Element {
        const heirarchy = (
            <PropsWrapper>
                <Parent>
                    <Child>
                        <GrandChild />
                    </Child>
                </Parent>
            </PropsWrapper>
        );

        return heirarchy;
    }
}

export {PropsWrapper, PropsWrapperActions}