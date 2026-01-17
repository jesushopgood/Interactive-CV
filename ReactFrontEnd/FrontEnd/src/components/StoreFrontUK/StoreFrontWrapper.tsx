import type { JSX } from "react";
import WrapperActionsBase from "../../component-tree/WrapperActionsBase";
import { TabContainer } from "../Common/Layout/TabContainer";
import { CustomerList } from "./CustomerList";
import { CodeSnippet } from "../Common/CodeSnippet/CodeSnippet";
import codeSnippetMetaData from "../Common/CodeSnippet/CodeSnippetMeta";

interface StoreFrontWrapperProps
{
    children? : React.ReactNode;
}

// eslint-disable-next-line @typescript-eslint/no-unused-vars
export default function StoreFrontWrapper(_: StoreFrontWrapperProps){
    return (
        <div className="card-shadow p-2" id="context-wrapper">
            <div className="card-header mb-sm-4" > 
                <h3 className="mb-2 fs-5 p-2 text-uppercase bg-primary text-white"> State Wrapper</h3>
                <div className="mb-2 p-2 fs-md-5 bg-primary text-white">
                    Demonstrates all major built in hooks.
                </div>
            </div>
                
            <div className="card-body rounded p-0 mt-2" >
                {new StoreFrontWrapperActions().getHeirarchy()}
            </div>  
        </div>
    );
}
 
class StoreFrontWrapperActions extends WrapperActionsBase
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
                        title={codeSnippetMetaData.get("StoreFrontUK.CustomersList")?.title ?? ""} 
                        notes={codeSnippetMetaData.get("StoreFrontUK.CustomersList")?.notes ?? ""}>
                        <CustomerList />        
                    </CodeSnippet>
                },
            ]}/>
        );
    }

    getHeirarchyAsString(): JSX.Element {
        return (
            <StoreFrontWrapper>
                <TabContainer>
                    <CustomerList />
                </TabContainer>
            </StoreFrontWrapper>
        );
    }    
}

export {StoreFrontWrapper, StoreFrontWrapperActions}