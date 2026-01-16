import { useState, type JSX } from "react";
import { AnnotationContext } from "./AnnotationContext";

interface AnnotationProviderProps
{
    children: JSX.Element;
}

export const AnnotationProvider = ({children}: AnnotationProviderProps) => {
    const [showAnnotations, setShowAnnotations] = useState(true);

    const toggleAnnotations = () => {
        setShowAnnotations(prev => {
            const next = !prev;
            return next;
        });
    };

    return (
        <AnnotationContext.Provider value ={{showAnnotations, toggleAnnotations }}>
            {children}
        </AnnotationContext.Provider>
    )
}