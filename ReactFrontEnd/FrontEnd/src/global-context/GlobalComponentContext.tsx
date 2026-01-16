import { createContext } from "react";
import type IGlobalComponentContextType from "./IGlobalComponentContextType";

export const GlobalComponentContext = createContext<IGlobalComponentContextType | undefined>(undefined);      