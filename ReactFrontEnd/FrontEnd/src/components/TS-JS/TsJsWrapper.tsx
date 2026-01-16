import type { JSX } from "react";
import WrapperActionsBase from "../../component-tree/WrapperActionsBase";
import { TabContainer } from "../Common/Layout/TabContainer";
import AsyncClosures from "./AsyncClosures";
import CodeSnippet from "../Common/CodeSnippet/CodeSnippetSimple";
import codeSnippetMetaData from "../Common/CodeSnippet/CodeSnippetMeta";
import SimpleClosure from "./SimpleClosure";
import StaleUseEffect from "./StaleUseEffect";
import LiveClosure from "./LiveClosure";

export default function TsJsWrapper(){
    return (
        <div className="card-shadow p-2" id="context-wrapper">
            <div className="card-header mb-sm-4" > 
                <h3 className="mb-2 fs-5 p-2 text-uppercase bg-primary text-white"> State Wrapper</h3>
                <div className="mb-2 p-2 fs-md-5 bg-primary text-white">
                    Demonstrates Variaous Complex or Confusing (to me) Typescript and Javascript Concepts.
                </div>
            </div>
                
            <div className="card-body rounded p-0 mt-2" >
                {new TsJsWrapperActions().getHeirarchy()}
            </div>  
        </div>
    );
}

class TsJsWrapperActions extends WrapperActionsBase
{
    getHeirarchyAsString(): JSX.Element {
        return (
            <TsJsWrapper>
                <TabContainer>
                    <SimpleClosure />
                    <AsyncClosures />
                    <StaleUseEffect />
                    <LiveClosure />
                </TabContainer>
            </TsJsWrapper>
        )
    }
    getHeirarchy(): JSX.Element {
        return (
            <TabContainer
                tabs={[
                {
                    id: "staleClosures",
                    label: "Stale Closures",
                    content: 
                        <TabContainer tabs={[
                        {
                            id:"simpleClosure",
                            label:"Simple Closure",
                            content:
                            <CodeSnippet 
                                title={codeSnippetMetaData.get("SimpleClosures")?.title ?? ""} 
                                notes={codeSnippetMetaData.get("SimpleClosures")?.notes ?? ""}>
                                <SimpleClosure />
                            </CodeSnippet>
                        },    
                        {
                            id:"asyncIssues",
                            label:"Async Issues",
                            content:
                            <CodeSnippet 
                                title={codeSnippetMetaData.get("StaleClosures")?.title ?? ""} 
                                notes={codeSnippetMetaData.get("StaleClosures")?.notes ?? ""}>
                                <AsyncClosures />
                            </CodeSnippet>
                        },
                        {
                            id:"staleUseEffect",
                            label:"Stale Effect",
                            content:
                            <CodeSnippet 
                                title={codeSnippetMetaData.get("StaleEffect")?.title ?? ""} 
                                notes={codeSnippetMetaData.get("StaleEffect")?.notes ?? ""}>
                                <StaleUseEffect />
                            </CodeSnippet>
                        },
                        {
                            id:"liveClosure",
                            label:"Live Closure",
                            content:
                            <CodeSnippet 
                                title={codeSnippetMetaData.get("LiveClosure")?.title ?? ""} 
                                notes={codeSnippetMetaData.get("LiveClosure")?.notes ?? ""}>
                                <LiveClosure />
                            </CodeSnippet>
                        }
                    ]} />   
                }
            ]} />
        )
    }   
}

export {TsJsWrapper, TsJsWrapperActions}