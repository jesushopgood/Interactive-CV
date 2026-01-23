/* eslint-disable react-hooks/exhaustive-deps */
import { type JSX, type ReactNode } from "react";

export interface TabDefinition {
  id: string;
  label: string;
  allowClose?:boolean;
  content: ReactNode;
}

interface TabContainerProps {
  tabs?: TabDefinition[];
  currentTabId?: string;
  initialTabId?: string;
  onTabChange?: (id: string) => void;
  onClose?: (id: string) => void
  children?: JSX.Element | JSX.Element[] | null;
}

export function StoreFrontTabContainer({ tabs = [], currentTabId, initialTabId, onTabChange, onClose }: TabContainerProps) {
  const activeTabId = currentTabId ?? initialTabId;
  
  const updateActiveTab = (id: string) => {
    if(id) onTabChange?.(id);
  };

  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  const handleClose = (e: any, tabId: string) => {
    //We sit inside a button and we dont want the click to propogate up
    e.stopPropagation(); 
    onClose?.(tabId)
  }

  return (
    <div className="tab-container">
      <div className="tab-header">
        {tabs.map((tab) => (
          <button key={tab.id} className={`tab-btn ${activeTabId === tab.id ? "active" : ""}`} 
                    onClick={() => updateActiveTab(tab.id)}> 
            <span>{tab.label}</span>
            { tab.allowClose && <span className="close" onClick={(e) => handleClose(e, tab.id)}>×</span> }
          </button>
        ))}
      </div>

      <div className="tab-content">
        {tabs.find((t) => t.id === activeTabId)?.content}
      </div>
    </div>
  );
}