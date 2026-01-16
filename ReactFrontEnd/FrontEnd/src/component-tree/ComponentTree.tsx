import type { ReactElement } from "react";
import React from "react";
import type HierarchyMenuProps from "./HeirarchyMenuProps";

class ComponentTree
{
  public static stringifyHeirarchy(element: ReactElement, indent: number = 0): string {
    // skip DOM tags like <div>    
    if (typeof element.type === "string") return "";

    const name = element.type.name ?? element.name ?? "Anonymous";
    const padding = " ".repeat(indent);

    let result = `${padding}<${name}>\n`;

    if (element.props.children) {
      React.Children.forEach(element.props.children, child => {
        if (React.isValidElement(child)) {
          result += ComponentTree.stringifyHeirarchy(child, indent + 4);
        }
      });
    }

    result += `${padding}</${name}>\n`;
    return result;
  }

    public static heirarchyToList(element: ReactElement,
                                  key: number = 1,
                                  onItemClick: (name: string) => void,
                                  selectedMenuItem: string): ReactElement | null 
    { 
      // skip DOM tags like <div>
      if (typeof element.type === "string") return null;
      
      const name = element.type.name ?? "Anonymous";
      const children: ReactElement[] = [];
      key++;

      if (element.props.children) {
        React.Children.forEach(element.props.children, child => {
          if (React.isValidElement(child)) {
            const childResult = ComponentTree.heirarchyToList(child, key, onItemClick, selectedMenuItem);
            if (childResult) {
              children.push(childResult);
              key++;
            }
          }
        });
      }

      return (
        <li key={key}>
          <i className="bi bi-arrow-return-right"></i> 
          <button
                className={
                    "btn btn-link fs-6 text-primary" +
                    (selectedMenuItem  && selectedMenuItem === name ? "text-primary fw-bold fs-5" : " text-primary fw-normal")
                }
                onClick={() => onItemClick(name)}
            >{name}</button>

          { children.length > 0 && <ul className={`d-block ms-${Math.min(key, 5)} list-unstyled`}>{children}</ul> }
        </li>
      );
    }

  public static heirarchyMenu({ root, onItemClick, selectedMenuItem }: HierarchyMenuProps ){

    const tree = ComponentTree.heirarchyToList(root, 1, onItemClick, selectedMenuItem ?? "");
    
    return (
      <ul className="list-unstyled">
        <ul className="d-block ms-1 list-unstyled">{tree}</ul>
      </ul>
    )
  }
}

export { ComponentTree };