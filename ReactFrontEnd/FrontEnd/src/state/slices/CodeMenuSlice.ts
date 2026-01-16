import type { StateCreator } from "zustand";
import type IGlobalStateContextType from "../types/IGlobalStateContextType";
import type ICodeMenuStateType from "../types/ICodeMenuStateType";
export const createMenuStateSlice: StateCreator<IGlobalStateContextType, [], [], ICodeMenuStateType> 
  = (set, get) => ({
  isCodeMenuOpen: true,
  openCodeMenu: () => set({ isCodeMenuOpen: true }),
  closeCodeMenu: () => set({ isCodeMenuOpen: false }),
  toggleCodeMenu: () => set({ isCodeMenuOpen: !get().isCodeMenuOpen })
});