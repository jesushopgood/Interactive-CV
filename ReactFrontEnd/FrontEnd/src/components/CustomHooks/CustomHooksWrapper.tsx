import type { JSX } from "react";
import { TabContainer } from "../Common/Layout/TabContainer";
import DebounceClient from "./DebounceClient";
import WrapperActionsBase from "../../component-tree/WrapperActionsBase";
import SubscriptionClient from "./SubscriptionClient";
import ThrottleClient from "./ThrottleClient";
import { SpeedTypeClient } from "./SpeedTypeClient";
import LocalStorageClient from "./LocalStorageClient";
import UsePreviousClient from "./UsePreviousClient";
import FetchClient from "./FetchClient";
import TimeoutIntervalClient from "./TimeoutIntervalClient";
import CodeSnippet from "../Common/CodeSnippet/CodeSnippetSimple";
import codeSnippetMetaData from "../Common/CodeSnippet/CodeSnippetMeta";


export default function CustomHooksWrapper(){
    return (
        <div className="card-shadow p-2" id="context-wrapper">
            <div className="card-header mb-sm-4" > 
                <h3 className="mb-2 fs-5 p-2 text-uppercase bg-primary text-white"> State Wrapper</h3>
                <div className="mb-2 p-2 fs-md-5 bg-primary text-white">
                    Demonstrates all major built in hooks.
                </div>
            </div>
                
            <div className="card-body rounded p-0 mt-2" >
                {new CustomHooksWrapperActions().getHeirarchy()}
            </div>  
        </div>
    );
}

class CustomHooksWrapperActions extends WrapperActionsBase
{
    getHeirarchy(): JSX.Element {
        return (
            <TabContainer
                tabs={[   
                {
                    id: "useDebounce",
                    label: "useDebouce",
                    content:
                    <CodeSnippet 
                        title={codeSnippetMetaData.get("UseDebounce")?.title ?? ""} 
                        notes={codeSnippetMetaData.get("UseDebounce")?.notes ?? ""}>
                        <DebounceClient />
                    </CodeSnippet>
                },
                {
                    id: "useSubscriber",
                    label: "useSubscriber",
                    content:
                    <CodeSnippet 
                        title={codeSnippetMetaData.get("UseSubscriber")?.title ?? ""} 
                        notes={codeSnippetMetaData.get("UseSubscriber")?.notes ?? ""}>
                        <SubscriptionClient />
                    </CodeSnippet> 
                },
                {
                    id: "useThrottler",
                    label: "useThrottler",
                    content: 
                    <CodeSnippet 
                        title={codeSnippetMetaData.get("UseThrottler")?.title ?? ""} 
                        notes={codeSnippetMetaData.get("UseThrottler")?.notes ?? ""}>
                        <ThrottleClient />
                    </CodeSnippet> 
                },
                {
                    id: "useSpeedType",
                    label: "useSpeedType",
                    content:
                    <CodeSnippet 
                        title={codeSnippetMetaData.get("UseSpeedType")?.title ?? ""} 
                        notes={codeSnippetMetaData.get("UseSpeedType")?.notes ?? ""}>
                        <SpeedTypeClient />
                    </CodeSnippet> 
                },
                {
                    id: "useLocalStorage",
                    label: "useLocalStorage",
                    content:
                    <CodeSnippet 
                        title={codeSnippetMetaData.get("UseLocalStorage")?.title ?? ""} 
                        notes={codeSnippetMetaData.get("UseLocalStorage")?.notes ?? ""}>
                        <LocalStorageClient />
                    </CodeSnippet> 
                },
                {
                    id: "usePrevious",
                    label: "usePrevious",
                    content:
                    <CodeSnippet 
                        title={codeSnippetMetaData.get("UsePrevious")?.title ?? ""} 
                        notes={codeSnippetMetaData.get("UsePrevious")?.notes ?? ""}>
                        <UsePreviousClient />
                    </CodeSnippet> 
                },
                {
                    id: "useFetch",
                    label: "useFetch",
                    content: 
                    <CodeSnippet 
                        title={codeSnippetMetaData.get("UseFetch")?.title ?? ""} 
                        notes={codeSnippetMetaData.get("UseFetch")?.notes ?? ""}>
                        <FetchClient />
                    </CodeSnippet>
                    
                },
                {
                    id: "useTimoutInterval",
                    label: "useTimoutInterval",
                    content: 
                    <CodeSnippet 
                        title={codeSnippetMetaData.get("UseTimeoutInterval")?.title ?? ""} 
                        notes={codeSnippetMetaData.get("UseTimeoutInterval")?.notes ?? ""}>
                        <TimeoutIntervalClient />
                    </CodeSnippet>
                }
            ]}/>
        );
    }

    getHeirarchyAsString(): JSX.Element {
        return (
            <CustomHooksWrapper>
                <TabContainer>
                    <DebounceClient />
                    <SubscriptionClient />
                    <ThrottleClient />
                    <SpeedTypeClient />
                    <LocalStorageClient />
                    <UsePreviousClient />
                    <FetchClient />
                    <TimeoutIntervalClient />
                </TabContainer>
            </CustomHooksWrapper>
        );
    }   
}

export {CustomHooksWrapper, CustomHooksWrapperActions}