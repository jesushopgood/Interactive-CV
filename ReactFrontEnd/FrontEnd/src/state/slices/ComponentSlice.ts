import type { StateCreator } from "zustand";
import type ComponentPathMapping from "../../global-context/ComponentPathMapping";
import type IComponentStateType from "../types/IComponentStateType";
import type IGlobalStateContextType from "../types/IGlobalStateContextType";

export const createComponentSlice =
  (registeredComponents: ComponentPathMapping[]): StateCreator<IGlobalStateContextType, [], [], IComponentStateType> =>
  (set, get) => ({
    selectedComponentName: "",
    getComponent: (key: string) =>
      registeredComponents.find(x => x.componentName === key),
    setSelectedComponentName: (componentName: string) =>
      set({ selectedComponentName: componentName }),
    getSelectedComponentName: () => get().selectedComponentName
  })