/* eslint-disable @typescript-eslint/no-explicit-any */
export function withHighlight<T>(component: T, title: string, description: string, snippet: string) {
  const anyComponent = component as any;
  anyComponent.code = snippet;
  anyComponent.title = title;
  anyComponent.description = description;
  return component;
}