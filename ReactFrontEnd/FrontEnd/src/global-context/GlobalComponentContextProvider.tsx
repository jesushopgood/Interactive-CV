import { useState, type JSX } from "react";
import { GlobalComponentContext } from "./GlobalComponentContext";
import type ComponentPathMapping from "./ComponentPathMapping";

interface GlobalComponentContextProviderProps
{
    children: JSX.Element;
    registeredComponents: ComponentPathMapping[];
}

export const GlobalComponentContextProvider = ({children, registeredComponents}: GlobalComponentContextProviderProps) => {
        
    const [componentPathMapping] = useState<ComponentPathMapping[]>(registeredComponents);
    const [isCodeViewOpen, setIsCodeViewOpen] = useState(false);
    const [selectedComponentName, setSelectedComponentName] = useState<string>("");
    
    const getComponent = (componentName: string) => componentPathMapping.find(x => x.componentName === componentName);
    const openCodeView = () => setIsCodeViewOpen(true);
    const closeCodeView = () => setIsCodeViewOpen(false);
    const toggleCodeView = () => setIsCodeViewOpen(prev => !prev);
    const setComponentName = (componentName: string) => setSelectedComponentName(componentName);

    return (
        <GlobalComponentContext.Provider value ={
            {
                getComponent, 
                openCodeView, 
                closeCodeView, 
                toggleCodeView,
                setComponentName, 
                isCodeViewOpen,
                selectedComponentName }}>
            {children}
        </GlobalComponentContext.Provider>
    )
}