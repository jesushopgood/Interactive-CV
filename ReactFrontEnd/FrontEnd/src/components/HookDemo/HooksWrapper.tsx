import type { JSX } from "react";
import UseStateDemo, { UseStateClient } from "./State/UseStateDemo";
import { TabContainer } from "../Common/Layout/TabContainer";
import UseCallbackClient from "./UseCallbackClient";
import WrapperActionsBase from "../../component-tree/WrapperActionsBase";
import CodeSnippet from "../Common/CodeSnippet/CodeSnippetSimple";
import codeSnippetMetaData from "../Common/CodeSnippet/CodeSnippetMeta";
import UseTransitionClient from "./UseTransitionClient";
import UseDeferredValueClient from "./UseDeferredValueClient";
import { UseMemoClient } from "./UseMemoClient";
import { ParentComponent } from "./ContextApi/ParentComponent";
import ChildComponent from "./ContextApi/ChildComponent";
import GrandchildComponent from "./ContextApi/GrandchildComponent";
import { LoggedInUserProvider, UseContextClient } from "./ContextApi/LoggedInUserProvider";
import { UseReducerClient } from "./State/UseReducerDemo";
import UseRefDemo, { UseRefClient } from "./UseRefDemo";
import PhraseGame, { UseEffectClient } from "./UseEffectClient";
import CodeSnippetCompound from "../Common/CodeSnippet/CompoundCodeSnippet";

export default function HooksWrapper(){
    return (
        <div className="card-shadow p-2" id="context-wrapper">
            <div className="card-header mb-sm-4" > 
                <h3 className="mb-2 fs-5 p-2 text-uppercase bg-primary text-white"> State Wrapper</h3>
                <div className="mb-2 p-2 fs-md-5 bg-primary text-white">
                    Demonstrates all major built in hooks.
                </div>
            </div>
                
            <div className="card-body rounded p-0 mt-2" >
                {new HooksWrapperActions().getHeirarchy()}
            </div>  
        </div>
    );
}
 
class HooksWrapperActions extends WrapperActionsBase
{
    getHeirarchy(): JSX.Element {
        return (
            <TabContainer
                tabs={[
                {
                    id: "useState",
                    label: "useState",
                    content: 
                    <CodeSnippet 
                        title={codeSnippetMetaData.get("UseState")?.title ?? ""} 
                        notes={codeSnippetMetaData.get("UseState")?.notes ?? ""}>
                        <UseStateClient />        
                    </CodeSnippet>
                },
                {
                    id: "useReducer",
                    label: "useReducer",
                    content:
                    <CodeSnippet 
                        title={codeSnippetMetaData.get("UseReducer")?.title ?? ""} 
                        notes={codeSnippetMetaData.get("UseReducer")?.notes ?? ""}> 
                        <UseReducerClient />
                    </CodeSnippet>   
                },
                {
                    id: "useRef",
                    label: "useRef",
                    content:
                    <CodeSnippet 
                        title={codeSnippetMetaData.get("UseRef")?.title ?? ""} 
                        notes={codeSnippetMetaData.get("UseRef")?.notes ?? ""}> 
                        <UseRefClient />
                    </CodeSnippet>
                },
                {
                    id: "useEffect",
                    label: "useEffect",
                    content:
                    <CodeSnippet 
                        title={codeSnippetMetaData.get("UseEffect")?.title ?? ""} 
                        notes={codeSnippetMetaData.get("UseEffect")?.notes ?? ""}>
                        <UseEffectClient />
                    </CodeSnippet>     
                },
                {
                    id: "useMemo",
                    label: "useMemo",
                    content:
                    <CodeSnippet 
                        title={codeSnippetMetaData.get("UseMemo")?.title ?? ""} 
                        notes={codeSnippetMetaData.get("UseMemo")?.notes ?? ""}>
                        <UseMemoClient />
                    </CodeSnippet> 
                    
                },
                {
                    id: "useCallback",
                    label: "useCallback",
                    content:
                    <CodeSnippet 
                        title={codeSnippetMetaData.get("UseCallback")?.title ?? ""} 
                        notes={codeSnippetMetaData.get("UseCallback")?.notes ?? ""}>
                        <UseCallbackClient />
                    </CodeSnippet> 
                },
                {
                    id: "useTransition",
                    label: "useTransition",
                    content:
                    <CodeSnippet 
                        title={codeSnippetMetaData.get("UseTransitionClient")?.title ?? ""} 
                        notes={codeSnippetMetaData.get("UseTransitionClient")?.notes ?? ""}>
                        <UseTransitionClient />
                    </CodeSnippet> 
                },
                {
                    id: "useDeferredValue",
                    label: "useDeferredValue",
                    content:
                    <CodeSnippet 
                        title={codeSnippetMetaData.get("useDeferredValueClient")?.title ?? ""} 
                        notes={codeSnippetMetaData.get("useDeferredValueClient")?.notes ?? ""}>
                        <UseDeferredValueClient />
                    </CodeSnippet>    
                },
                {
                    id: "useContext",
                    label: "useContext",
                    content:
                    <CodeSnippet 
                        title={codeSnippetMetaData.get("UseContext")?.title ?? ""} 
                        notes={codeSnippetMetaData.get("UseContext")?.notes ?? ""}>
                        <UseContextClient>
                            <LoggedInUserProvider>
                                <ParentComponent>
                                    <ChildComponent>
                                        <GrandchildComponent />
                                    </ChildComponent>
                                </ParentComponent>
                            </LoggedInUserProvider>
                        </UseContextClient>
                    </CodeSnippet> 
                    
                }
            ]}/>
        );
    }

    getHeirarchyAsString(): JSX.Element {
        return (
            <HooksWrapper>
                <TabContainer>
                    <UseStateDemo />
                    <UseReducerClient />
                    <UseRefDemo />
                    <PhraseGame />
                    <UseMemoClient />
                    <UseCallbackClient />
                    <UseTransitionClient />
                    <UseDeferredValueClient />
                    <LoggedInUserProvider>
                            <ParentComponent>
                                <ChildComponent>
                                    <GrandchildComponent />
                                </ChildComponent>
                            </ParentComponent>
                        </LoggedInUserProvider>
                </TabContainer>
            </HooksWrapper>
        );
    }    
}

export {HooksWrapper, HooksWrapperActions}