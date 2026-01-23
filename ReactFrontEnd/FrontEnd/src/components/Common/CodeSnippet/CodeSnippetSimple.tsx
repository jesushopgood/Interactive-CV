/* eslint-disable react-hooks/exhaustive-deps */
import { useEffect, useState, type JSX } from "react";
import { useStore } from "../../../state";
import { HighlightPopup } from "../../Highlight/HighlightPopup";

interface CodeSnippetProps
{
    title: string;
    notes: string;
    children: JSX.Element;
}

interface HighlightProps
{
    title: string;
    description: string;
    code: string;
}

export default function CodeSnippetSimple({title, notes, children}: CodeSnippetProps){
    const [showHighlight, setShowHighlight] = useState(false);
    const [highlight, setHighlight] = useState<HighlightProps | null>();
    const setComponentName = useStore(s => s.setSelectedComponentName);
    const toggleCodeView = useStore(s => s.toggleCodeView);
    const isCodeViewOpen = useStore(s => s.isCodeViewOpen);
    const closeCodeMenu = useStore(s => s.closeCodeMenu);

    useEffect(() => {
        // eslint-disable-next-line @typescript-eslint/no-explicit-any
        const component = children.type as any;
 
        if (component.code){
            setHighlight({
                title: component.title ?? "", 
                description: component.description ?? "",
                code: component.code ?? ""
            });
        }
        
        setComponentName(children.type.displayName || children.type.name || 'Unknown');
    }, [children])

    const updateCodeMenuVisibility = () => {
        toggleCodeView();

        if (!isCodeViewOpen) closeCodeMenu();
    }

    return (
        <div className="container-fluid border border-1 border-primary p-3">
            <div className="d-flex justify-content-between mb-2">
                <h2 className="fs-5 text-primary fw-bold">{title}</h2>
                <div className="d-flex justify-content-end gap-2">
                    {
                    highlight &&
                    <button className="btn btn-primary text-white btn-sm" onClick={() => setShowHighlight(true)}>
                        Show Highlight
                    </button>
                    }
                    <button className="btn btn-secondary btn-sm" onClick={updateCodeMenuVisibility}>
                        {isCodeViewOpen ? "Hide Code" : "View Code" }
                    </button>
                </div>
            </div>
            <p className="my-4 p-3 bg-primary fw-bold text-white border-bottom border-2">{notes}</p>
            <div className="mb-4">
                {children}
            </div>
            {showHighlight && highlight && (
            <HighlightPopup 
                title={highlight.title} 
                description={highlight.description} 
                snippet={highlight.code} onClose={() => setShowHighlight(false)}
            />
        )}   
        </div>
    )   
}
