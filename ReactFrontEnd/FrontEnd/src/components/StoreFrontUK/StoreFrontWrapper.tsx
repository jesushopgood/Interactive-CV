/* eslint-disable react-hooks/set-state-in-effect */
import { useEffect, useState, type JSX } from "react";
import WrapperActionsBase from "../../component-tree/WrapperActionsBase";
import { TabContainer, type TabDefinition } from "../Common/Layout/TabContainer";
import { CustomerList } from "./Customers/CustomerList";
import { CodeSnippet } from "../Common/CodeSnippet/CodeSnippet";
import codeSnippetMetaData from "../Common/CodeSnippet/CodeSnippetMeta";
import CustomerDetail from "./Customers/customerDetail";

interface StoreFrontWrapperProps
{
    children? : React.ReactNode;
}

// eslint-disable-next-line @typescript-eslint/no-unused-vars
export default function StoreFrontWrapper(_: StoreFrontWrapperProps){
    const [, setTick] = useState(0);
    const [wrapperActions, setWrapperActions] = useState<StoreFrontWrapperActions | null>(null);

    useEffect(() => {
        setWrapperActions(new StoreFrontWrapperActions());
    }, [])

    useEffect(() => {
        wrapperActions?.setRerender(() => setTick(t => t + 1));
    } , [wrapperActions]);

    return (
        <div className="card-shadow p-2" id="context-wrapper">
            <div className="card-header mb-sm-4" > 
                <h3 className="mb-2 fs-5 p-2 text-uppercase bg-primary text-white"> State Wrapper</h3>
                <div className="mb-2 p-2 fs-md-5 bg-primary text-white">
                    Demonstrates all major built in hooks.
                </div>
            </div>
                
            <div className="card-body rounded p-0 mt-2" >
                {wrapperActions?.getHeirarchy()}
            </div>  
        </div>
    );
}
 
class StoreFrontWrapperActions extends WrapperActionsBase
{
    private tabs: TabDefinition[];

    constructor(){
        super();

        this.tabs = [{
                    id: "customerList",
                    label: "Customer List",
                    content: 
                    <CodeSnippet 
                        title={codeSnippetMetaData.get("StoreFrontUK.CustomersList")?.title ?? ""} 
                        notes={codeSnippetMetaData.get("StoreFrontUK.CustomersList")?.notes ?? ""}>
                        <CustomerList onSelectCustomer={(customerId: string) => this.openCustomerDetails(customerId)}/>        
                    </CodeSnippet>
        }];
    }
    
    openCustomerDetails(customerId: string){
        if (this.tabs.some(t => t.id === `customer-${customerId}`)) return;

        this.tabs.push({
                    id: `customer-${customerId}`,
                    label: "Customer",
                    content: 
                    <CodeSnippet 
                        title={codeSnippetMetaData.get("StoreFrontUK.CustomersList")?.title ?? ""} 
                        notes={codeSnippetMetaData.get("StoreFrontUK.CustomersList")?.notes ?? ""}>
                        <CustomerDetail customerId={customerId} />        
                    </CodeSnippet>
        });

        this.notify();
    }

    getHeirarchy(): JSX.Element {
        return <TabContainer tabs={this.tabs} />;
    }

    getHeirarchyAsString(): JSX.Element {
        return (
            <StoreFrontWrapper>
                <TabContainer>
                    <CustomerList />
                    <CustomerDetail />
                </TabContainer>
            </StoreFrontWrapper>
        );
    }    
}

export {StoreFrontWrapper, StoreFrontWrapperActions}