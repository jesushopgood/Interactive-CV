import type { JSX } from "react";
import type WrapperActionsBase from "../component-tree/WrapperActionsBase";

export default interface ComponentPathMapping
{
    componentName: string;
    component: JSX.Element;
    menuActions: WrapperActionsBase;
    componentPath: string;
}