import type ComponentPathMapping from "../../global-context/ComponentPathMapping";

export default interface IComponentStateType
{
    getComponent: (key: string) => ComponentPathMapping | undefined;
    setSelectedComponentName: (componentName: string) => void;
    getSelectedComponentName:() => string;
    selectedComponentName: string;
}