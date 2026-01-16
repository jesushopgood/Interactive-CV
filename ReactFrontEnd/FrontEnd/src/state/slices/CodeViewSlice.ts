import type { StateCreator } from "zustand";
import type IGlobalStateContextType from "../types/IGlobalStateContextType";
import type ICodeViewContextType from "../types/ICodeViewStateType";

export const createCodeViewSlice: StateCreator<IGlobalStateContextType, [], [], ICodeViewContextType> 
  = (set, get) => ({
  isCodeViewOpen: false,
  openCodeView: () => set({ isCodeViewOpen: true }),
  closeCodeView: () => set({ isCodeViewOpen: false }),
  toggleCodeView: () => set({ isCodeViewOpen: !get().isCodeViewOpen }),
});