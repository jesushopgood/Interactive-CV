/* eslint-disable react-hooks/set-state-in-effect */
import { useEffect, useState, type JSX } from "react";
import WrapperActionsBase from "../../component-tree/WrapperActionsBase";
import { CodeSnippet } from "../Common/CodeSnippet/CodeSnippet";
import codeSnippetMetaData from "../Common/CodeSnippet/CodeSnippetMeta";
import CustomerAddresses from "./Customers/CustomerAdddresses";
import CustomerContacts from "./Customers/CustomerContacts";
import CustomerNotes from "./Customers/CustomerNotes";
import CustomerDetail from "./Customers/CustomerDetail";
import CustomerListNew from "./Customers/CustomerListNew";
import { StoreFrontTabContainer, type TabDefinition } from "./Layout/StoreFrontTabContainer";

export type entityId = string;

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
    private activeTabId: string = "customerList";

    constructor(){
        super();
        this.tabs = [{
                    id: "customerList",
                    label: "Customer List",
                    allowClose: false,
                    content: 
                    <CodeSnippet 
                        title={codeSnippetMetaData.get("StoreFrontUK.CustomersList")?.title ?? ""} 
                        notes={codeSnippetMetaData.get("StoreFrontUK.CustomersList")?.notes ?? ""}>
                        <CustomerListNew onSelectEntity={(customerId: string) => this.viewCustomerDetails(customerId)}/>
                    </CodeSnippet>
        }];
    }

    private updateTabName(customerId: string, tabName: string){        
        const tab = this.tabs.find(t => t.id === customerId);
        if (!tab) return;
        if (tab) tab.label = tabName;

        this.notify();
    }

    private backToResults = () => {
        this.activeTabId = "customerList"; 
        this.notify();
    }   

    private closeTab  = (id: entityId) => {
        this.tabs = this.tabs.filter(t => t.id !== id);
        this.activeTabId = "customerList"
        this.notify();
    }

    private selectExistingTab = (tabId: string) => {
        this.activeTabId = tabId;
        this.notify();
        return;
    }

    private createNewTab = (entityId: string) => {
        this.tabs.push({
            id: entityId,
            label: "Customer",
            allowClose: true,
            content: 
            <CodeSnippet 
                title={codeSnippetMetaData.get("StoreFrontUK.CustomerDetail")?.title ?? ""} 
                notes={codeSnippetMetaData.get("StoreFrontUK.CustomerDetail")?.notes ?? ""}>
                <CustomerDetail customerId={entityId} 
                                onLoaded={(tabName) => this.updateTabName(entityId, tabName)}
                                onBackToResults={this.backToResults} />        
            </CodeSnippet>
        });

        this.activeTabId = entityId;
        this.notify();
    }
    
    viewCustomerDetails(entityId: string){
        const existingTab = this.tabs.find(t => t.id === entityId);
        if (existingTab)
            this.selectExistingTab(existingTab.id);
        else
            this.createNewTab(entityId);
    }

    getHeirarchy(): JSX.Element {
        return <StoreFrontTabContainer tabs={this.tabs} 
                        currentTabId={this.activeTabId}
                        onTabChange={(id: string) => {
                            this.activeTabId = `${id}`;
                            this.notify();
                        }}
                        onClose={(id: string) => this.closeTab(id)} 
                />;
    }

    getHeirarchyAsString(): JSX.Element {
        return (
            <StoreFrontWrapper>
                <StoreFrontTabContainer>
                    <CustomerListNew />
                    <CustomerDetail />
                    <CustomerAddresses />
                    <CustomerNotes  />
                    <CustomerContacts />
                </StoreFrontTabContainer> 
            </StoreFrontWrapper>
        );
    }    
}

export {StoreFrontWrapper, StoreFrontWrapperActions}