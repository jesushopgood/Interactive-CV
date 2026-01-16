import { createContext } from "react";

export interface AnnotationContextType {
    showAnnotations: boolean;
    toggleAnnotations: () => void | null;
}

export const AnnotationContext = createContext<AnnotationContextType | undefined>(undefined);   