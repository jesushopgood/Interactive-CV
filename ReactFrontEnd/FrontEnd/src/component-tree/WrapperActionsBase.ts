import type { JSX } from "react";
import { ComponentTree } from "./ComponentTree";

export default abstract class WrapperActionsBase
{
    private rerender!: () => void

    abstract getHeirarchyAsString(): JSX.Element;

    abstract getHeirarchy(): JSX.Element;

    getHeirarchyMarkup(handleClick: (name: string) => void, selectedMenuItem: string): JSX.Element {
        return ComponentTree.heirarchyMenu({
            root: this.getHeirarchyAsString(),
            onItemClick: handleClick,
            selectedMenuItem    
        });
    }

    setRerender(fn: () => void) {
        this.rerender = fn;
    }

    notify() {
        this.rerender?.();
    }
}