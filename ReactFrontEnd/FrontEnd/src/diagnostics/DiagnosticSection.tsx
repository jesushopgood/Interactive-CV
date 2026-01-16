/* eslint-disable react-hooks/exhaustive-deps */
/* eslint-disable react-hooks/set-state-in-effect */
import { useEffect, useState } from "react";
import CodeWindow from "./Components/CodeWindow";
import ComponentMenu from "./Components/ComponentMenu";
import type IDiagnosticSectionProps from "./Props/IDiagnosticSectionProps";
import { useStore } from "../state";

export default function DiagnosticsSection({componentPathMapping} : IDiagnosticSectionProps){
    const [filename, setFileName] = useState<string | null>(null);
    const [codePath, setCodePath] = useState<string | null>(null);

    const baseName = componentPathMapping?.componentName ?? "";
    const basePath = componentPathMapping?.componentPath ?? ""
    const selectedName = filename ?? baseName;
    const selectedPath = codePath ?? `${basePath}/${baseName}`;
    const selectedComponentName = useStore(s => s.selectedComponentName);
    
    const handleClick = (selectedName: string) => {
        const formattedPath = `${componentPathMapping?.componentPath}/${selectedName}`;
        setCodePath(formattedPath);
        setFileName(selectedName);
    }

    useEffect(() => {
        if (selectedComponentName) handleClick(selectedComponentName)
    },[selectedComponentName])
    
    return(
        <>
        { 
            componentPathMapping && 
            <>
                <ComponentMenu onClick={handleClick} componentMapping={componentPathMapping} />
                <CodeWindow componentPath={selectedPath} componentName={selectedName} />
            </>
        }
        </>
    )        
}