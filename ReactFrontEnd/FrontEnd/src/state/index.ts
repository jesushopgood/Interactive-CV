import { create } from "zustand";
import type IGlobalStateContextType from "./types/IGlobalStateContextType";
import { createComponentSlice } from "./slices/ComponentSlice";
import { createCodeViewSlice } from "./slices/CodeViewSlice";
import type ComponentPathMapping from "../global-context/ComponentPathMapping";
import getInitialComponent from "../component-tree/getInitialComponent";
import { createAnnotationsSlice } from "./slices/AnnotationSlice";
import { createMenuStateSlice } from "./slices/CodeMenuSlice";

export const initializeStore = (registeredComponents: ComponentPathMapping[]) =>
  create<IGlobalStateContextType>()((...args) => ({
    ...createComponentSlice(registeredComponents)(...args),
    ...createCodeViewSlice(...args),
    ...createAnnotationsSlice(...args),
    ...createMenuStateSlice(...args)
  }));

export const useStore = initializeStore(getInitialComponent());
