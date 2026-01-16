import Prism from "prismjs";
import "prismjs/themes/prism.css";
import "prismjs/components/prism-javascript";
import "prismjs/components/prism-typescript";
import { useEffect } from "react";

type HighlightPopupProps = {
  title: string;
  description: string;
  snippet: string;
  onClose: () => void;
};

export function HighlightPopup({ title, description, snippet, onClose }: HighlightPopupProps) {
  
  useEffect(() => {
    Prism.highlightAll();
  }, [description, snippet])
  
  return (
    <div className="highlight-overlay" onClick={onClose}>
      <div className="highlight-modal" onClick={(e) => e.stopPropagation()}>
        <h2 className="fs-5 mb-4">{title}</h2>
        <div className="border border-1 border-light p-3 rounded">
          <div className="container-fluid p-0 mb-3 ">{description}</div>
          <pre className="rounded p-2 language-typescript"><code>{snippet}</code></pre>
        </div>
      </div>
    </div>
  );
}