import type { JSX } from "react";
import type IComponentContainer from "./IComponentContainer";
import { type IMenuComponent } from "../../../component-tree/IMenuComponent";

export default class ComponentContainerFactory
{
    static Create(component: JSX.Element, actions: IMenuComponent): IComponentContainer
    {
        return { Component: component, Actions: actions } as IComponentContainer
    }
}