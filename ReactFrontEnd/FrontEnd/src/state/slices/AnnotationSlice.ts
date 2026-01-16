import type { StateCreator } from "zustand";
import type { IAnnotationType } from "../types/IAnnotationType";
import type IGlobalStateContextType from "../types/IGlobalStateContextType";

export const createAnnotationsSlice: StateCreator<IGlobalStateContextType, [], [], IAnnotationType> = (set) => ({
  showAnnotations: false,
  toggleAnnotations: () => set(state => ({ showAnnotations: !state.showAnnotations }))
});