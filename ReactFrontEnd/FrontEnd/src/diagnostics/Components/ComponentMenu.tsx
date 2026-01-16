/* eslint-disable react-hooks/exhaustive-deps */
import { useEffect, useState } from "react";
import type ComponentPathMapping from "../../global-context/ComponentPathMapping";
import { useStore } from "../../state";

interface ComponentMenuProps
{
    componentMapping: ComponentPathMapping;
    onClick: (name: string) => void;
}

export default function ComponentMenu({componentMapping, onClick} : ComponentMenuProps)
{   
    const [selectedMenuItem, setSelectedMenuItem] = useState<string | null>(null);
    const selectedComponentName = useStore(s => s.selectedComponentName);
    const isCodeMenuOpen = useStore(s => s.isCodeMenuOpen);
    const toggleCodeMenu = useStore(s => s.toggleCodeMenu);
    
    const handleClick = (name: string) => {
        setSelectedMenuItem(name);
        onClick(name);
    }

    useEffect(() => {
        if (selectedComponentName) {
            handleClick(selectedComponentName);       
        }
            
    },[selectedComponentName])

    const selectedMenuValue = selectedMenuItem ?? componentMapping.componentName;
    const componentHeirarchy = componentMapping.menuActions.getHeirarchyMarkup(handleClick, selectedMenuValue);

    return (
        <div className="container-fluid accordion p-0 mb-4" id="accordianExample">
            <div className="accordion-item">
                <h2 className="accordion-header">
                    <button className={`accordion-button ${!isCodeMenuOpen ? "collapsed" : ""}`} onClick={() => toggleCodeMenu()} type="button">
                        {isCodeMenuOpen ? "Hide" : "Show" } Menu   
                    </button>
                </h2>
                <div id="collapseOne" 
                        className={`accordion-collapse collapse ${isCodeMenuOpen ? "show" : "hide"}`}>
                        <div className="accordion-body">    
                            <div className="card-shadow">
                                <div className="card-header">
                                    <h3 className="text-uppercase fs-6">View Component Menu {isCodeMenuOpen ? "On" : "Off"}</h3>
                                </div>    
                                <div className="card-body">
                                    {componentHeirarchy}
                                </div>
                            </div>
                        </div>
                </div>
            </div>
        </div>
    )
}