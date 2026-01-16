import { useState, type ReactNode } from "react";

export interface TabDefinition {
  id: string;
  label: string;
  content: ReactNode;
}

interface TabContainerProps {
  tabs: TabDefinition[];
  initialTabId?: string;
}

export function TabContainer({ tabs, initialTabId }: TabContainerProps) {
  const [activeTab, setActiveTab] = useState(
    initialTabId ?? tabs[0].id
  );

  return (
    <div className="tab-container">
      <div className="tab-header">
        {tabs.map((tab) => (
          <button
            key={tab.id}
            className={`tab-btn ${activeTab === tab.id ? "active" : ""}`}
            onClick={() => setActiveTab(tab.id)}
          >
            {tab.label}
          </button>
        ))}
      </div>

      <div className="tab-content">
        {tabs.find((t) => t.id === activeTab)?.content}
      </div>
    </div>
  );
}