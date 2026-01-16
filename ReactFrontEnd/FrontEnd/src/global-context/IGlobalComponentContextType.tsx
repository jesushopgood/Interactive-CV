import type ComponentPathMapping from "./ComponentPathMapping";

export default interface IGlobalComponentContextType extends IComponentContextType, ICodeViewContextType{}

interface IComponentContextType
{
    getComponent: (key: string) => ComponentPathMapping | undefined;
    setComponentName: (componentName: string) => void;
    selectedComponentName: string
}

interface ICodeViewContextType
{
    openCodeView: () => void,
    closeCodeView: () => void,
    toggleCodeView: () => void,
    isCodeViewOpen: boolean
}
