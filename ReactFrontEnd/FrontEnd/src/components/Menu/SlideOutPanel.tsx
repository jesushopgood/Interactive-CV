/* eslint-disable react-hooks/exhaustive-deps */
/* eslint-disable react-hooks/set-state-in-effect */
import { useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import type IDiagnosticSectionProps from "../../diagnostics/Props/IDiagnosticSectionProps";
import DiagnosticsSection from "../../diagnostics/DiagnosticSection";
import { useStore } from "../../state";

export function SlideOutPanel({componentPathMapping} : IDiagnosticSectionProps) {
  const menuWidths = {
    Diagnostics: 800,
    Annotations: 500
  }

  const isCodeViewOpen = useStore(x => x.isCodeViewOpen);
  const openCodeMenu = useStore(x => x.openCodeMenu);
  
  const [open, setOpen] = useState<boolean | null>(null);
  const [activeTab, setActiveTab] = useState("Diagnostics");
  const [width, setWidth] = useState(menuWidths.Diagnostics);

  const handleOpenClick = (open: boolean) => {
    setOpen(open);
    if (open) openCodeMenu();
  }

  useEffect(() => {
        if (open === null) 
          setOpen(false);
        else {
          setOpen(prev => !prev);        
        }
          
  }, [isCodeViewOpen])
  
  const setTab = (tabName: string) => {
    switch(tabName){
        case "Diagnostics":
            setWidth(menuWidths.Diagnostics);
            break;
        case "Annotations":
            setWidth(menuWidths.Annotations);
            break;
    }
    setActiveTab(tabName)
  }

  return (
    <>
      {/* Toggle Button */}
      <button className="btn btn-primary position-fixed" 
                style={{ right: open ? width : 0, top: "40%", transition: "right 0.5s ease, transform 1s ease" }} 
                onClick={() => handleOpenClick(!open)}
                >
        {open ? "Close" : "Menu"}
      </button>

      {/* Slide-out container */}
      <div
        className="bg-light border-start shadow"
        style={{
          position: "fixed",
          top: 0,
          right: 0,
          width: width,
          height: "100vh",
          transform: open ? "translateX(0)" : "translateX(100%)",
          transition: "width 0.5s ease, transform 1s ease",
          display: "flex",
        }}
      >
        {/* Vertical Tabs */}
        <div
          className="nav flex-column nav-pills p-2 border-end"
          style={{ width: 80 }}
        >
          <button className={`nav-link ${activeTab === "diagnostics" ? "active" : ""}`} 
            onClick={() => setTab("Diagnostics")}>D</button>

          <button
            className={`nav-link ${activeTab === "annotations" ? "active" : ""}`}
            onClick={() => setTab("Annotations")}>A</button>
        </div>

        {/* Tab Content */}
        <div className="p-3 flex-grow-1 overflow-auto">
          {activeTab === "Diagnostics" && (
            <>
                <h5 className="slideout-menu">Diagnostics</h5>
                <DiagnosticsSection componentPathMapping={componentPathMapping} />
            </>  
          )}

          {activeTab === "Annotations" && (
            <>
              <h5 className="slideout-menu">Annotations</h5>
              <p>Your annotation data goes here.</p>
            </>
          )}
        </div>
      </div>
    </>
  );
}