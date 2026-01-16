import { useEffect, useState } from "react";
import Prism from "prismjs";
import "prismjs/themes/prism.css";
import "prismjs/components/prism-javascript";
import "prismjs/components/prism-typescript";

interface CodeWindowProps {
  componentPath: string;
  componentName: string | undefined;
}

function escapeHtml(code: string) {
  return code
    .replace(/&/g, "&amp;")
    .replace(/</g, "&lt;")
    .replace(/>/g, "&gt;");
}

export default function CodeWindow({ componentPath, componentName }: CodeWindowProps) {
  const [component, setComponent] = useState<string | null>(null);
  const modules = import.meta.glob("../../components/**/*.tsx", { as: "raw" });

  const updateComponent = (rawCode: string) => {
    setComponent(rawCode);
    Prism.highlightAll();
  }

  useEffect(() => {
    if (!componentPath) return;

    const matchedPath = Object.keys(modules).find((key) => key.includes(`${componentName}.tsx`));

    if (!matchedPath) {
      console.error("No module found for:", matchedPath);
      return;
    }

    modules[matchedPath]()
      .then((rawCode: string) => updateComponent(rawCode))
      .catch((err: any) => console.error("Failed to load component:", err));
  }, [componentPath, modules]);

  useEffect(() => {
    if (component) Prism.highlightAll();
  }, [component]);

  return (
    <div className="scrollable-parent">
      <div className="card-shadow">
        <div className="card-header">
          <h3 className="fs-6 text-success">{componentName}.tsx</h3>
        </div>
        <div className="card-body my-scrollable-div">
            <pre className="p-1">
              <code
                className="language-typescript"
                dangerouslySetInnerHTML={{
                  __html: component ? escapeHtml(component) : "",
                }}
              />
            </pre> 
          </div> 
      </div>
    </div>
  );
}