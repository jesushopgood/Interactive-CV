import React, { type JSX } from "react";
import CodeSnippetCompound from "./CompoundCodeSnippet";
import CodeSnippetSimple from "./CodeSnippetSimple";

interface CodeSnippetProps
{
    title: string;
    notes: string;
    children: JSX.Element;
}

export function CodeSnippet( props : CodeSnippetProps ) {
    const { children } = props;

    const isCompound = React.Children.toArray(children).some(child => {
        if (!React.isValidElement(child)) return false;
        const type = child.type as any;
        return Boolean(type.__isCodeSnippetSubcomponent);
    });

  return isCompound ? (<CodeSnippetCompound {...props} />) : (<CodeSnippetSimple {...props} />);
}
