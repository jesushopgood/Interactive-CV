import type { JSX } from "react";

export default interface HierarchyMenuProps
{
  root : JSX.Element;
  onItemClick: (name: string) => void; 
  selectedMenuItem?: string;
}