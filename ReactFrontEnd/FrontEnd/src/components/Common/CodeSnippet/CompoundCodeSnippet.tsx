    /* eslint-disable react-hooks/refs */
    import { createContext, useContext, useRef, type JSX } from "react";
    import { useStore } from "../../../state";

    interface CodeSnippetState
    {
        setSelectedComponentName: (name: string) => void;
        toggleCodeView: () => void;
    }
    
    const SnippetContext = createContext<CodeSnippetState | null>(null);

    export default function CodeSnippetCompound({ children } : { children : React.ReactNode}) {
        const setSelectedComponentName = useStore(s => s.setSelectedComponentName);
        const toggleCodeView = useStore(s => s.toggleCodeView);
        
        const codeSnippetStateRef = useRef({ 
            setSelectedComponentName,
            toggleCodeView,
        } as CodeSnippetState);

        return (
            <SnippetContext.Provider value={codeSnippetStateRef.current}>
                <div className="container-fluid border border-1 border-primary p-3">
                    {children}
                </div>
            </SnippetContext.Provider>
        );
    }

    CodeSnippetCompound.Header = function({ children } : { children : React.ReactNode}){
        return (
            <div className="d-flex justify-content-between mb-2">
            {children}
            </div>
        );            
    };

    CodeSnippetCompound.Title = function Title({ children } : { children : React.ReactNode}) {
    return <h2 className="fs-5 text-primary fw-bold">{children}</h2>;
    };

    CodeSnippetCompound.Toggle = function Toggle() {
        const context = useContext(SnippetContext);
        const toggleCodeView = context?.toggleCodeView;
        const isOpen = useStore(s => s.isCodeViewOpen);

        return (
            <button className="btn btn-secondary btn-sm" onClick={toggleCodeView}>
            {isOpen ? "Hide Code" : "View Code"}
            </button>
        );
    };

    CodeSnippetCompound.Notes = function Notes({children} : {children : React.ReactNode})  {
        return (
            <p className="my-4 p-3 bg-primary fw-bold text-white border-bottom border-2">
                {children}
            </p>
        );
    };

    CodeSnippetCompound.ComponentHolder = function ComponentHolder({children} : {children : JSX.Element}) {  
        const context = useContext(SnippetContext);
        context!.setSelectedComponentName(children?.type.displayName || children.type.name || 'Unknown');
        
        return <div className="mb-4">{children}</div>;
    };